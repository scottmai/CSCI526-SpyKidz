using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
  [SerializeField] private string loadLevel; //visible in inspector
    void Start() {
      print("HI 1");
      Debug.Log("HI 2");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      Debug.Log("ENTERED");
      if(other.CompareTag("Player")) {
        Debug.Log("GOT TO PLAYER");
        SceneManager.LoadScene(loadLevel);
      }

    }
}
