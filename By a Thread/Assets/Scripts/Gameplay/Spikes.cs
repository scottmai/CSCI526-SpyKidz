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
            Schedule<PlayerDeath>();
        }

    }
}
