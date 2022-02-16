using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Model;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// DeathZone components mark a collider which will schedule a
    /// PlayerEnteredDeathZone event when the player enters the trigger.
    /// </summary>
    public class DeathZone : MonoBehaviour
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
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "Level", model.level},
                    { "Zone", this.name }
                };
                Debug.Log(this.name);
                Events.CustomData("PlayerDeath", parameters);
                Events.Flush();
                var ev = Schedule<PlayerEnteredDeathZone>();
                ev.deathzone = this;
            }
        }
    }
}