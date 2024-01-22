using Core.Spawner;
using Core.UI.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Door
{
    public class InteractReceiver : Core.Interaction.InteractReceiver
    {
        [SerializeField] private Ctrl ctrl;


        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCtrl(ref this.ctrl);
        }

        public override void OnInteract()
        {
            this.ToggleState();
        }

        private void ToggleState()
        {
            DoorStateManager stateManager = this.ctrl.DoorStateManager;
            stateManager.ToggleDoor();
        }
    }
}