using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement : MonoBehaviour
{
    [SerializeField] GameObject slider;
    [SerializeField] GameObject slider2;
    private float movementSpeed = 2f;
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
            if(slider2.transform.position.x >= 23.15f)
            {
                slider2.transform.position = slider2.transform.position - new Vector3(movementSpeed * Time.deltaTime, 0, 0);
            }
        }
    }
}
