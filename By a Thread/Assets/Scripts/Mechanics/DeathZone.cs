using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Model;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Analytics;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// DeathZone components mark a collider which will schedule a
    /// PlayerEnteredDeathZone event when the player enters the trigger.
    /// </summary>
    public class DeathZone : MonoBehaviour
    {
        private LifeManager lifeManager;

        async void Start()
        {
            lifeManager = FindObjectOfType<LifeManager>();
        }
        
        void OnTriggerEnter2D(Collider2D collider)
        {
            PlatformerModel model = Simulation.GetModel<PlatformerModel>();
            var p = collider.gameObject.GetComponent<PlayerForceController>();
            if (p != null)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "Level", model.level.ToString()},
                    { "Zone", this.name }
                };

                // remove life
                if (!lifeManager.AlreadyDead())
                {
                    lifeManager.RemoveLife();
                }
                

                AnalyticsEvent.Custom("PlayerDeath", parameters);
                AudioSource audsrc = GetComponent<AudioSource>();
                audsrc.Play();
           
                var ev = Schedule<PlayerEnteredDeathZone>();
                ev.deathzone = this;
            }
        }
    }
}