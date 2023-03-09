using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private int maxTime;
    private float moveX;
    private float moveZ;
    public float speed = 1.0f;
    private int nextUpdate=1;
    bool gameFinished;

    public TextMeshProUGUI countText;
    public TextMeshProUGUI timeText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public GameObject restartObject;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        maxTime = 60;
        gameFinished = false;

        SetCountText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        restartObject.SetActive(false);
    }

     
    // Update is called once per frame
    void Update(){
        // If the next update is reached
        if(Time.time>=nextUpdate && maxTime>0 && gameFinished==false){
            // Change the next update (current second+1)
            nextUpdate=Mathf.FloorToInt(Time.time)+1;
            // Call your fonction
            maxTime -=1;
            timeText.text = maxTime.ToString();
            if (maxTime == 0){
                gameFinished = true;
                loseTextObject.SetActive(true);
                restartObject.SetActive(true);
            }
        }
     
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        moveX = movementVector.x;
        moveZ = movementVector.y;
        Debug.Log(movementVector);
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count>=12)
        {
            gameFinished = true;
            winTextObject.SetActive(true);
            restartObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (gameFinished==false)
        {
            Vector3 force = new Vector3(moveX, 0.0f, moveZ);
            rb.AddForce(force * speed);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            if (gameFinished == false)
            {
                count+=1;
                SetCountText();
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            if (gameFinished == false)
            {
                gameFinished = true;
                loseTextObject.SetActive(true);
                restartObject.SetActive(true);
            }   
        }
    }
}
