using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Spring : MonoBehaviour
{
    public Rigidbody2D rb;

    public float releaseTime = 0.15f;
    private bool isPressed = false;

    private float velocity = 15f;

    void  Update() {
        if(isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            rb.bodyType = RigidbodyType2D.Static;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

            rb.MovePosition((new Vector3(Input.GetAxis("HorizontalAlternate"), 0, 0)*Time.deltaTime*velocity) + transform.position);
    }
    private void OnMouseDown() {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp() {
        isPressed = false;
        rb.isKinematic = false;

        //StartCoroutine(Release());
    }
    
    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
    }
}
