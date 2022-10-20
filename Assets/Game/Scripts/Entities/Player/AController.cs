using Invector.vCharacterController;
using RPGBatler.Player.Interface;

namespace RPGBatler.Player
{
    public abstract class AController : vThirdPersonController, IInteractableController, IAttacableController
    {
        public abstract void ControlInteract();
        public abstract void ControlAttack();
    }
}