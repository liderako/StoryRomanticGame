using RPGBatler.NPC.States;
using RPGBatler.NPC.States.Interfaces;
using RPGBatler.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

namespace RPGBatler.NPC
{

    public class NPCCombatAvatar : ACombatAvatar
    {
        private RagdollsAvatar ragdollsAvatar;
        private const string ATTACK = "Attack";
        private const string HIT = "Hit";
        private IState moveStateBehavior;
        private IState actionStateBehavior;
        private Animator animator;

        private void Awake()
        {
            this.animator = base.GetComponent<Animator>();
            base.HealthSystem = base.GetComponent<Game.Scripts.HealthSystem.HealthSystem>();
            this.ragdollsAvatar = base.GetComponent<RagdollsAvatar>();
            this.typeUnit = "StreetBandit";
        }
        
        private IEnumerator CoolDownAction()
        {
            IState tmp = actionStateBehavior;
            actionStateBehavior = null;
            yield return new WaitForSecondsRealtime(0.7f);
            actionStateBehavior = tmp;
        }

        public override void Death()
        {
            this.ragdollsAvatar.ActivateRagDoll();
            Destroy(this);
        }

        public void InitBattleState(GameObject player)
        {
            this.InitMoveState(player);
            RPGBatler.NPC.States.BattleState state1 = new RPGBatler.NPC.States.BattleState();
            state1.Animator = this.animator;
            state1.owner = this;
            state1.target = player;
            this.actionStateBehavior = state1;
        }

        private void InitMoveState(GameObject player)
        {
            MoveState state1 = new MoveState();
            state1.Animator = this.animator;
            state1.Agent = base.GetComponent<NavMeshAgent>();
            state1.target = player;
            state1.owner = this;
            this.moveStateBehavior = state1;
        }

        public override void Punch()
        {
            base.Punch();
            this.animator.SetTrigger("Attack");
            base.StartCoroutine(this.CoolDownAction());
        }

        public override void ReceiveHit(int damage)
        {
            base.ReceiveHit(damage);
            this.animator.SetTrigger("Hit");
        }

        private void Update()
        {
            this.UpdateMoveState();
            this.UpdateActionState();
        }

        private void UpdateActionState()
        {
            if (this.actionStateBehavior != null)
            {
                this.actionStateBehavior.UpdateState();
            }
        }

        private void UpdateMoveState()
        {
            if (this.moveStateBehavior != null)
            {
                this.moveStateBehavior.UpdateState();
            }
        }
        
    }
}
