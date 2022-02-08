using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotMovement : MonoBehaviour
{
    [SerializeField] GameObject pivot;
    private float movementSpeed = 3f;
    private bool flag = false;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name == "Player1" | other.gameObject.name == "Player2")
        {
            flag = true;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(flag)
        {
            if(pivot.transform.rotation.z >= 0f)
            {
                pivot.transform.Rotate(0, 0, -1,Space.Self);
            }
        }
    }
}
