using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
  [SerializeField] private string loadLevel; //visible in inspector
    void OnTriggerEnter2D(Collider2D other)
    {

        Scene scene = SceneManager.GetActiveScene();
        if (other.CompareTag("Player")) {
            print(scene.name);
            if (scene.name == "Level 1") {
                SceneManager.LoadScene("Level 2");
            }
            
        }
    }
}
