using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
  // void Start()
  //   {
  //
  //       Button button = GetComponent<Button>();
  //       Debug.Log("button" + button);
  //     }
     public void RestartGame() {
         // SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
         // Debug.Log("SceneManager.GetActiveScene().buildIndex"+ SceneManager.GetActiveScene().buildIndex);
         SceneManager.LoadScene("Level1");
     }
}
