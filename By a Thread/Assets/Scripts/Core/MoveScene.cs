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
        
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
          { "Level", model.level}
        };
        
        Events.CustomData("LevelComplete", parameters);
        Events.Flush();
        SceneManager.LoadScene(loadLevel);
      }
    }
}
