using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="PlayerDeathNew"></typeparam>
    public class PlayerDeathNew : Simulation.Event<PlayerDeathNew>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        
        public PlayerController player;
        public override void Execute()
        {
            if (player.health.IsAlive)
            {
                player.health.Die();
                model.virtualCamera.m_Follow = null;
                model.virtualCamera.m_LookAt = null;
                // player.collider.enabled = false;
                player.controlEnabled = false;

                if (player.audioSource && player.ouchAudio)
                    player.audioSource.PlayOneShot(player.ouchAudio);
                player.animator.SetTrigger("hurt");
                player.animator.SetBool("dead", true);
                Simulation.Schedule<PlayerSpawnNew>(2).player = player;
            }
            
            
            
        }
    }
}