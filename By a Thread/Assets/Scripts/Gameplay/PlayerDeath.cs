using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="PlayerDeath"></typeparam>
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            Debug.Log("Player co-ords: ");
            Debug.Log(model.player.transform.position);
           // model.TotalCoinsCollected = 0;
            KillPlayer(model.player2);
            KillPlayer(model.player);
            
        }

        public void KillPlayer(PlayerForceController player)
        {
            if (player.health > 0)
            {
                player.health = 0;
                // player.collider.enabled = false;
                player.controlEnabled = false;
                player.isDead = true;
                player.animator.SetTrigger("any-death");

                //if (player.audioSource && player.ouchAudio)
                //    player.audioSource.PlayOneShot(player.ouchAudio);
                //player.spriteRenderer.enabled = false;
                Simulation.Schedule<PlayerSpawn>(.5f).player = player;


            }
        }
    }
}