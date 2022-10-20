using UnityEngine;
using Invector.vCharacterController;
using VIDE_Data;

namespace RPGBatler.Player
{
    public class PlayerInput : vThirdPersonInput
    {
        [Header("Advance Controller Input")]
        [SerializeField] private KeyCode attackInput = KeyCode.Mouse0;
        [SerializeField] private KeyCode interactInput = KeyCode.E;
        private AController aControler;
        
        protected override void Start()
        {
            base.Start();
            aControler = GetComponent<AController>();
        }
        protected override void InputHandle()
        {
            if (IsAvailableForInput())
            {
                base.InputHandle();
                AttackInput();
                InteractInput();
            }
        }

        private void AttackInput()
        {
            if (Input.GetKeyDown(attackInput))
            {
                aControler.ControlAttack();
            }
        }

        private void InteractInput()
        {
            if (Input.GetKeyDown(interactInput))
            {
                aControler.ControlInteract();
            }
        }

        private bool IsAvailableForInput()
        {
            if (IsDialogLoaded())
            {
                return false;
            }
            return true;
        }

        private bool IsDialogLoaded()
        {
            return VD.isActive;
        }
    }
}