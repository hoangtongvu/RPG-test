using Core;
using Core.Animator;
using System;
using UnityEngine;

namespace Player.StateMachine.States
{
    public class IdleState : BaseState
    {

        protected override void ResetValue()
        {
            base.ResetValue();
            this.isRootState = false;
        }

        public override void HandleAnimation()
        {
            BaseAnimator baseAnimator = this.ctrl.BaseAnimator;
            baseAnimator.ChangeAnimationState("Idle");
        }

        public override void StateFixedUpdate()
        {
        }

        public override void StateOnEnter()
        {
            InputManager inputManager = InputManager.Instance;
            inputManager.onLeftMousePressed.AddListener(this.SwitchAttackState);
        }

        public override void StateOnExit()
        {
            InputManager inputManager = InputManager.Instance;
            inputManager.onLeftMousePressed.RemoveListener(this.SwitchAttackState);
        }

        public override void StateUpdate()
        {
            this.CheckSwitchState();
        }

        protected override void CheckSwitchState()
        {
            
        }

        protected override void InitSubState()
        {
        }

        protected virtual void SwitchAttackState()
        {
            this.SwitchState("Attack");
        }
    }
}