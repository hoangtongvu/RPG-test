using System;
using UnityEngine;

namespace Player.StateMachine
{
    public abstract class BaseState : Core.StateMachine.BaseState
    {
        [SerializeField] protected Ctrl ctrl;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCtrl();
        }

        private void LoadCtrl()
        {
            this.ctrl = transform.parent?.parent?.parent?.GetComponent<Ctrl>();
        }
    }
}