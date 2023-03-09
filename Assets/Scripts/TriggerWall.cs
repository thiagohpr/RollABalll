using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWall : MonoBehaviour
{
    private double maxHeight;
    private double minHeight;
    private int movementState;
    void Start()
    {
        maxHeight = 4.0;
        minHeight = 0.5;
        movementState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementState==0) //Subindo
        {
            if (transform.position[1]<=maxHeight)
            {
                transform.Translate(new Vector3(0,1,0) * Time.deltaTime);
            }
            else
            {
               movementState=1; 
            }
        }
        if (movementState==1) //Descendo
        {
            if (transform.position[1]>=minHeight)
            {
                transform.Translate(new Vector3(0,-1,0) * Time.deltaTime);
            }
            else
            {
               movementState=0; 
            }
        }
        
    }
}
