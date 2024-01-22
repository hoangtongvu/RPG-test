using Core.Item;
using System;
using UnityEngine;

namespace Core.Inventory
{
    [Serializable]
    public class InventoriedItemDeductor
    {
        [SerializeField] private Inventory inventory;

        public InventoriedItemDeductor(Inventory inventory)
        {
            this.inventory = inventory;
        }

        public virtual void DeductItem(ItemCode itemCode, int deductCount)
        {
            InventoriedItem inventoriedItem;
            int deduct;

            for (int i = this.inventory.Items.Count - 1; i >= 0; i--)
            {
                if (deductCount <= 0) break;
                inventoriedItem = this.inventory.Items[i];
                if (inventoriedItem.ItemProfile.itemCode != itemCode) continue;

                if (deductCount > inventoriedItem.itemCount)
                {
                    deduct = inventoriedItem.itemCount;
                    deductCount -= inventoriedItem.itemCount;
                }
                else
                {
                    deduct = deductCount;
                    deductCount = 0;
                }

                inventoriedItem.itemCount -= deduct;
            }

            this.inventory.ClearItemSlot();
        }



    }
}
