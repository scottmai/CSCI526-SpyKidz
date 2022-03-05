using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Spring : MonoBehaviour
{
    public Rigidbody2D rb;
    private float velocity = 15f;

    void  Update() {
        
        
        if (Input.GetKey(KeyCode.S))
        {
            rb.bodyType = RigidbodyType2D.Static;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

            //rb.MovePosition((new Vector3(Input.GetAxis("HorizontalAlternate"), 0, 0)*Time.deltaTime*velocity) + transform.position);
    }
    }
