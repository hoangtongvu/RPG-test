using Core;
using System;
using UnityEngine;

namespace Player.StateMachine.States
{
    public class GroundedState : BaseState
    {

        protected override void ResetValue()
        {
            base.ResetValue();
            this.isRootState = true;
        }

        public override void HandleAnimation()
        {
            this.currentSubState.HandleAnimation();
        }

        public override void StateFixedUpdate()
        {
        }

        public override void StateOnEnter()
        {
            this.InitSubState();
        }

        public override void StateOnExit()
        {
        }

        public override void StateUpdate()
        {
            this.HandleAnimation();

        }

        protected override void CheckSwitchState()
        {

        }

        protected override void InitSubState()
        {
            this.SetSubState("Idle");
            Core.StateMachine.BaseState newSubState = this.GetStateByName("Idle");
            newSubState.StateOnEnter();
        }
    }
}