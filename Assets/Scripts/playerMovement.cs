using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float moveX;
    private float moveZ;
    public float speed = 1.0f;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 force = new Vector3(moveX, 0.0f, moveZ);
        rb.AddForce(force * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count+=1;
            SetCountText();
        }

    }
}
