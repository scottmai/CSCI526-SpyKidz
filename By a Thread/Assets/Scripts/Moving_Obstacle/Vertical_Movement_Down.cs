using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertical_Movement_Down : MonoBehaviour
{
    private bool up = false;
    private bool down = true;
    private float vertispd = 1f;

    void Update()
    {
        if(up)
        {
            if(transform.position.y < 3f)
            {
                transform.position = transform.position + new Vector3( 0, vertispd * Time.deltaTime, 0);
            }

            if(transform.position.y >= 2.89f)
            {
                up = false;
                down = true;
            }
        }

        if(down)
        {
            if(transform.position.y > -0.75f)
            {
                transform.position = transform.position - new Vector3( 0, vertispd * Time.deltaTime, 0);
            }

            if(transform.position.y <= -0.7f)
            {
                down = false;
                up = true;
            }
        }
    }
}
