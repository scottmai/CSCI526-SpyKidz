using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private float movementSpeed = 0.5f;
    private bool flag = false;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name == "Player1" | other.gameObject.name == "Player2")
        {
            flag = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flag)
        {
            if(transform.position.y <= 1.09f)
            {
                transform.position = transform.position + new Vector3(0, movementSpeed * Time.deltaTime, 0);
            }
        }
    }
}
