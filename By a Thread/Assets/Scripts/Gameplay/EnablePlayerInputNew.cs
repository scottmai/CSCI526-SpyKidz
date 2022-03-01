using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay
{
    /// <summary>
    /// This event is fired when user input should be enabled.
    /// </summary>
    public class EnablePlayerInputNew : Simulation.Event<EnablePlayerInputNew>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public PlayerForceController player;

        public override void Execute()
        {
            player.controlEnabled = true;
        }
    }
}