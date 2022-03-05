using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Spring2 : MonoBehaviour
{
     public Rigidbody2D rb;
    private float velocity = 15f;

    void  Update() {
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.bodyType = RigidbodyType2D.Static;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        //rb.MovePosition((new Vector3(Input.GetAxis("Horizontal"), 0, 0)*Time.deltaTime*velocity) + transform.position);
    }
    
}
