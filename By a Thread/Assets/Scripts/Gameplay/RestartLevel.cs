using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;
using Unity.Services.Analytics;
using Unity.Services.Core;

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
             { "Player1_x", model.player.transform.position.x},
             { "Player1_y", model.player.transform.position.y},
             { "Player2_x", model.player2.transform.position.x},
             { "Player2_y", model.player2.transform.position.y}
         };
         
         AnalyticsEvent.Custom("RestartLevel", parameters);
         Events.CustomData("RestartLevel", parameters);
         //Events.Flush();
         SceneManager.LoadScene(scene.name);
     }
}
