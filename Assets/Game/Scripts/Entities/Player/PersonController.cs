using Game.Scripts.UI;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace RPGBatler.Player
{
    public class PersonController : AController
    {
        private string attackAnimation;
        [SerializeField]
        private ADialogView dialogView;
        [SerializeField]
        private Transform center;
        private const int DISTANCE_RAY_INTERACT = 15;

        private void Awake()
        {
            this.InitData();
        }

        public override void ChangeLock(bool state)
        {
            if (!state)
            {
                base.stopMove = false;
                base.lockMovement = false;
            }
            else
            {
                base.stopMove = true;
                base.lockMovement = true;
                base.inputMagnitude = 0f;
            }
        }

        public override void ControlAttack()
        {
            base.animator.SetTrigger(this.attackAnimation);
        }

        public override void ControlInteract()
        {
            VIDE_Assign assign;
            if (this.TryInteractNPC(out assign))
            {
                this.InteractWithNPC(assign);
                this.ChangeLock(true);
            }
        }

        private void InitData()
        {
            this.attackAnimation = "Attack";
        }

        private void InteractWithNPC(VIDE_Assign assigned)
        {
            this.dialogView.Interact(assigned);
        }

        private bool TryInteractNPC(out VIDE_Assign assigned)
        {
            RaycastHit hit;
            VIDE_Assign assign;
            if (Physics.Raycast(this.center.position, base.transform.forward, out hit, 15f) && hit.collider.TryGetComponent<VIDE_Assign>(out assign))
            {
                assigned = assign;
                return true;
            }
            assigned = null;
            return false;
        }
    }
}