using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Movement2 : MonoBehaviour
{
    [SerializeField] GameObject rotator;
    private bool flag = true;
    private float rspeed = 10f;

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
