using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
  [SerializeField] private string loadLevel; //visible in inspector

  async void Start()
  {
    try
    {

      await UnityServices.InitializeAsync();
      List<string> consentIdentifiers = await Events.CheckForRequiredConsents();
    }
    catch (ConsentCheckException e)
    {
      Debug.Log("Should not happen");
    }
  }

  void OnTriggerEnter2D(Collider2D other)
    {

      if(other.CompareTag("Player")) {

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        // model.T.timerActive = false;

        // Dictionary<string, object> parameters = new Dictionary<string, object>()
        // {
        //   { "Level", model.level.ToString()},
        //   { "Attempts", model.DeathCount + 1},
        //   {"Time", model.T.timeStart}
        // };

        // Dictionary<string, object> coinparameters = new Dictionary<string, object>()
        // {
        //   { "Level", model.level.ToString()},
        //   { "NumOfCoinsCollected", model.TotalCoinsCollected}
        // };

        // Debug.Log(model.TotalCoinsCollected);
        Debug.Log("loadLevel" + loadLevel);

        // Events.CustomData("LevelComplete", parameters);
        // Events.CustomData("CoinsCollected", coinparameters);
        // Events.Flush();
        // model.level += 1;
        // model.DeathCount = 0;
        // model.TotalCoinsCollected = 0;
        // model.T.timeStart = 0.0f;
        // model.T.timerActive = true;
        SceneManager.LoadScene(loadLevel);
      }
    }
}
