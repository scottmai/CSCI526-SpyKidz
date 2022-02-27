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
            KillPlayer(model.player2);
            KillPlayer(model.player);
        }

        public void KillPlayer(PlayerController player)
        {
            if (player.health.IsAlive)
            {
                player.health.Die();
                // player.collider.enabled = false;
                player.controlEnabled = false;

                if (player.audioSource && player.ouchAudio)
                    player.audioSource.PlayOneShot(player.ouchAudio);
                player.spriteRenderer.enabled = false;
                Simulation.Schedule<PlayerSpawnNew>(.5f).player = player;
            }
        }
    }
}