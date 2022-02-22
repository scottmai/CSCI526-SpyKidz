using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player is spawned after dying.
    /// </summary>
    public class PlayerSpawnNew : Simulation.Event<PlayerSpawnNew>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public PlayerController player;

        public override void Execute()
        {
            player.spriteRenderer.enabled = true;
            player.collider2d.enabled = true;
            player.controlEnabled = false;
            if (player.audioSource && player.respawnAudio)
                player.audioSource.PlayOneShot(player.respawnAudio);
            player.health.Increment();
            
            player.Teleport(player.spawnPoint.transform.position);
            player.jumpState = PlayerController.JumpState.Grounded;
            player.animator.SetBool("dead", false);
            Simulation.Schedule<EnablePlayerInputNew>(0).player=player;
        }
    }
}