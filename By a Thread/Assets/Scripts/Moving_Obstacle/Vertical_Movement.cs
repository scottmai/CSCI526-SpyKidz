using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertical_Movement : MonoBehaviour
{
    private bool up = true;
    private bool down = false;
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
            if(transform.position.y > -0.70f)
            {
                transform.position = transform.position - new Vector3( 0, vertispd * Time.deltaTime, 0);
            }

            if(transform.position.y <= -0.70f)
            {
                down = false;
                up = true;
            }
        }
    }
}
