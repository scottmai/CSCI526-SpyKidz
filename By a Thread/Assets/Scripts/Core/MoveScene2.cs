using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using TMPro;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class MoveScene2 : MonoBehaviour
{
  [SerializeField] private string loadLevel; //visible in inspector
  public float Timer = 3.0f;
  public bool NotEnoughCoinsButCollidedFlag = false;
  
  async void Start()
  {

  }
  
  void OnTriggerEnter2D(Collider2D other)
    {
      PlatformerModel model = Simulation.GetModel<PlatformerModel>();
      
      if(other.CompareTag("Player") && model.TotalCoinsCollected >= model.MinimumCoinsRequired) {
        
        model.T.timerActive = false;
        
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
          { "Level", model.level.ToString()},
          { "Attempts", model.DeathCount + 1},
          {"Time", model.T.timeStart}
        };
        
        Dictionary<string, object> coinparameters = new Dictionary<string, object>()
        {
          { "Level", model.level.ToString()},
          { "NumOfCoinsCollected", model.TotalCoinsCollected}
        };
        Debug.Log(model.TotalCoinsCollected);
        AnalyticsEvent.Custom("LevelComplete", parameters);
        AnalyticsEvent.Custom("CompletedLevel", parameters);
        AnalyticsEvent.Custom("CoinsCollected", coinparameters);
        model.level += 1;
        MainManager.setLastLevelUnlocked(model.level);
        model.DeathCount = 0;
        model.TotalCoinsCollected = 0;
        model.T.timeStart = 0.0f;
        model.T.timerActive = true;
        SceneManager.LoadScene(loadLevel);
      }
      else
      {
        NotEnoughCoinsButCollidedFlag = true;
        GameObject bruh = GameObject.Find("Not-Enough-Coins2");
        bruh.GetComponent<SpriteRenderer>().enabled = true;
      }
    }

  private void Update()
  {

    if (!NotEnoughCoinsButCollidedFlag)
    {
      GameObject bruh = GameObject.Find("Not-Enough-Coins2");
      bruh.GetComponent<SpriteRenderer>().enabled = false;
    }
    else
    {
      Timer -= Time.deltaTime;
      
      if (Timer <= 0.0f)
      {
        NotEnoughCoinsButCollidedFlag = false;
        Timer = 3.0f;
      }
    }

  }
}
