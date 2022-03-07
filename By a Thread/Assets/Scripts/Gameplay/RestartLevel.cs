using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
  void Start()
    {

        // Button button = GetComponent<Button>();
        // Debug.Log("button" + button);
      }
     public void RestartGame() {
         // SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
         // Debug.Log("SceneManager.GetActiveScene().buildIndex"+ SceneManager.GetActiveScene().buildIndex);
         Scene scene = SceneManager. GetActiveScene();
         PlatformerModel model = Simulation.GetModel<PlatformerModel>();
         Dictionary<string, object> parameters = new Dictionary<string, object>()
         {
             { "Level", model.level.ToString()},
             { "Player1-x", model.player.transform.position.x},
             { "Player1-y", model.player.transform.position.y},
             { "Player2-x", model.player2.transform.position.x},
             { "Player2-y", model.player2.transform.position.y}
         };
         
         AnalyticsEvent.Custom("RestartLevel", parameters);
         SceneManager.LoadScene(scene.name);
     }
}
