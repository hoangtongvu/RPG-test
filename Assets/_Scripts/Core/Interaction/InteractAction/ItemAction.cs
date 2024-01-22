using Core.Inventory;
using System;
using Core.Interaction.ActionHandler;
using UnityEngine;

namespace Core.Interaction
{
    public class ItemAction : InteractActionHandler
    {
        [SerializeField] private Inventory.Inventory inventory;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadInventory();
        }
        void LoadInventory()
        {
            this.inventory = transform.parent?.GetComponentInChildren<Inventory.Inventory>();
        }

        public override bool PerformAction(InteractReceiver interactReceiver)
        {
            if (interactReceiver is not Core.Item.InteractReceiver) return false;

            Core.Item.InteractReceiver itemReceiver = (Core.Item.InteractReceiver)interactReceiver;
            if (!this.inventory.ItemAdder.AddItem(itemReceiver.Ctrl.InventoriedItem)) return true;
            interactReceiver.OnInteract();
            //Debug.Log("Action performed");
            return true;
        }

    }
}
