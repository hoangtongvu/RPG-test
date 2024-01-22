using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player.StateMachine
{
    public class StateMachine : Core.StateMachine.StateMachine
    {
        [SerializeField] private Core.StateMachine.BaseState groundedState;
        [SerializeField] protected Ctrl ctrl;


        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCtrl(ref this.ctrl);
        }

        protected override Core.StateMachine.BaseState GetDefaultState()
        {
            return this.groundedState;
        }


    }
}