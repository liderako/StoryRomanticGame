using Invector.vCharacterController;
using System;
using UnityEngine;
using VIDE_Data;

namespace RPGBatler.Player
{

    public class PlayerInput : vThirdPersonInput
    {
        [Header("Advance Controller Input"), SerializeField]
        private KeyCode attackInput = KeyCode.Mouse0;
        [SerializeField]
        private KeyCode interactInput = KeyCode.E;
        private AController aControler;

        private void AttackInput()
        {
            if (Input.GetKeyDown(this.attackInput))
            {
                this.aControler.ControlAttack();
            }
        }

        protected override void InputHandle()
        {
            if (this.IsAvailableForInput())
            {
                if (this.aControler.lockMovement)
                {
                    this.aControler.ChangeLock(false);
                }
                base.InputHandle();
                this.AttackInput();
            }
            this.InteractInput();
        }

        private void InteractInput()
        {
            if (Input.GetKeyDown(this.interactInput))
            {
                this.aControler.ControlInteract();
            }
        }

        private bool IsAvailableForInput() => 
            !this.IsDialogLoaded();

        private bool IsDialogLoaded() => 
            VD.isActive;

        protected override void Start()
        {
            base.Start();
            this.aControler = base.GetComponent<AController>();
        }

        protected override void Update()
        {
            base.cc.UpdateAnimator();
            this.InputHandle();
        }
    }
}