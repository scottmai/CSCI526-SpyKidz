using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Movement : MonoBehaviour
{

    [SerializeField] GameObject rotator;
    private bool flag = false;
    private float rspeed = 30f;

    private void OnCollisionEnter2D(Collision2D other) {
        flag = true;
    }

    private void OnCollisionExit2D(Collision2D other) {
        flag = false;
    }  
    void Update()
    {
        if(flag == true)
        {
            rotator.transform.Rotate(0, 0, rspeed*Time.deltaTime);
        }
    }
}
