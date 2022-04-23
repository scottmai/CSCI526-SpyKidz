using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player is spawned after dying.
    /// </summary>
    public class PlayerSpawn : Simulation.Event<PlayerSpawn>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public PlayerForceController player;

        public override void Execute()
        {
            // idk why but having this code in playerDeath gives incorrect values
            if (player == model.player) 
            {
                model.DeathCount += 1;
            }
            
            //player.spriteRenderer.enabled = true;
            //player.collider2d.enabled = true;
            player.controlEnabled = false;
            //if (player.audioSource && player.respawnAudio)
            //    player.audioSource.PlayOneShot(player.respawnAudio);
            player.health += 1;
            player.isDead = false;


            player.animator.ResetTrigger("any-death");


            player.Teleport(player.spawnPoint.transform.position);
            System.Threading.Thread.Sleep(200);



            //player.jumpState = PlayerController.JumpState.Grounded;
            //player.animator.SetBool("dead", false);
            Simulation.Schedule<EnablePlayerInputNew>(0).player = player;
            player.animator.SetTrigger("death-idle");
        }
    }
}