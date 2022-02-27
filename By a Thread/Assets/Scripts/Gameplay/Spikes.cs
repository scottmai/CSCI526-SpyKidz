using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;
using UnityEngine.Analytics;
using Unity.Services.Analytics;
using Unity.Services.Core;

public class Spikes : MonoBehaviour
{
    
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
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        var p = collider.gameObject.GetComponent<PlayerForceController>();
        if (p != null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Level", model.level},
                { "Zone", this.name }
            };
            
            Events.CustomData("PlayerDeath", parameters);
            Events.Flush();
            Schedule<PlayerDeath>();
        }

    }
}
