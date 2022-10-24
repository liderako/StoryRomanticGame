using Invector.vCharacterController;
using RPGBatler.Player.Interface;
using System;

namespace RPGBatler.Player
{

    public abstract class AController : vThirdPersonController, IInteractableController, IAttacableController, ILockerController
    {
        protected AController()
        {
        }

        public abstract void ChangeLock(bool state);
        public abstract void ControlAttack();
        public abstract void ControlInteract();
    }
}