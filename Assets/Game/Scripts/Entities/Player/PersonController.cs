using System;
using Game.Scripts.ScriptableObjects;
using Game.Scripts.UI.Interface;
using Invector.vCharacterController;
using RPGBatler.Player.Interface;
using UnityEngine;
using Zenject;

namespace RPGBatler.Player
{
    public class PersonController : AController
    {
        private string attackAnimation;

        [Inject]
        private IInteractableDialogView dialogView;
        // [SerializeField] private GameObject dialogView1;

        private void Awake()
        {
            InitData();
        }

        private void InitData()
        {
            attackAnimation = "Attack";
        }

        public override void ControlAttack()
        {
            animator.SetTrigger(attackAnimation);
        }

        public override void ControlInteract()
        {
            if (TryInteractNPC(out VIDE_Assign assigned))
            {
                InteractWithNPC(assigned);
                // UI.Interact
                // disable input?
                // change camera
            }
        }

        private void InteractWithNPC(VIDE_Assign assigned)
        {
            dialogView.Interact(assigned);
        }
        
        private bool TryInteractNPC(out VIDE_Assign assigned)
        {
            RaycastHit rHit;

            if (Physics.Raycast(transform.position, transform.forward, out rHit, 2))
            {
                if (rHit.collider.TryGetComponent(out VIDE_Assign assign))//GetComponent<VIDE_Assign>().?)
                {
                    assigned = assign;
                    return true;
                }
            }
            assigned = null;
            return false;
        }
    }
}