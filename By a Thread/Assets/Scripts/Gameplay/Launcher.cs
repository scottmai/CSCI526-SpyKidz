using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Platformer.Mechanics;

public class Launcher : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform LaunchDirection;
    public float launchForce = 300;

    public PlayerController playerController;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trigger) {

        if (trigger.GetComponent<PlayerController>() != null) {

            print("Touched" + playerController.name);
            float directionX = LaunchDirection.position.x;
            float directionY = LaunchDirection.position.y;
            float posX = transform.position.x;
            float posY = transform.position.y;

            Vector2 launchDir = new Vector2(directionX - posX, directionY - posY);
            print(launchDir);
            playerController.ExitLauncher(launchDir, launchForce);

        }
    }
}   
