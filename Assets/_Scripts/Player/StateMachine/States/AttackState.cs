using Core;
using Core.Animator;
using System;
using UnityEngine;

namespace Player.StateMachine.States
{
    public class AttackState : BaseState
    {
        [SerializeField] private AttackHandler attackHandler;
        [SerializeField] private BaseAnimator animator;

        [SerializeField] private float animLength;
        [SerializeField] private float aniTimer;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.animator = this.ctrl.BaseAnimator;
            this.attackHandler = this.ctrl.AttackHandler;
        }

        protected override void ResetValue()
        {
            base.ResetValue();
            this.isRootState = false;
            this.animLength = this.animator.GetAnimationLength("Attack");
        }

        public override void HandleAnimation()
        {
            BaseAnimator baseAnimator = this.ctrl.BaseAnimator;
            baseAnimator.ChangeAnimationState("Attack");
        }
        public override void StateOnEnter()
        {
            this.attackHandler.EnableWeaponCollider();
            this.aniTimer = 0;
        }

        public override void StateFixedUpdate()
        {
            this.CalculateAniTime();
        }


        public override void StateOnExit()
        {
            this.attackHandler.DisableWeaponCollider();
        }

        public override void StateUpdate()
        {
            this.CheckSwitchState();
        }

        protected virtual void CalculateAniTime()
        {
            this.aniTimer += Time.fixedDeltaTime;
        }

        protected override void CheckSwitchState()
        {
            if (this.aniTimer < this.animLength) return;
            this.SwitchState("Idle");
        }

        protected override void InitSubState()
        {
        }

    }
}