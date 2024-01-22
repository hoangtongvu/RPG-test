using System;
using UnityEngine;

namespace Core.Item
{
    public class InteractReceiver : Interaction.InteractReceiver
    {
        [SerializeField] private Ctrl ctrl;
        public Ctrl Ctrl => ctrl;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCtrl(ref this.ctrl);
        }

        public override void OnInteract() => this.OnPickUp();

        private void OnPickUp()
        {
            Debug.Log("Picked Item");

            this.DespawnItem();
        }

        private void DespawnItem()
        {
            ItemDespawner itemDespawner = this.ctrl.ItemDespawner;
            itemDespawner.DespawnObject();
        }

    }
}