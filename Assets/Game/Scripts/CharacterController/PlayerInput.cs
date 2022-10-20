using UnityEngine;

namespace Invector.vCharacterController
{
    public class PlayerInput : vThirdPersonInput
    {
        public KeyCode attackInput = KeyCode.Mouse0;
        private PersonController personController;
        
        protected override void Start()
        {
            base.Start();
            personController = GetComponent<PersonController>();
        }
        protected override void InputHandle()
        {
            base.InputHandle();
            AttackInput();
        }

        protected virtual void AttackInput()
        {
            if (Input.GetKeyDown(attackInput))
            {
                personController.ControllAttack();   
            }
        }
    }
}