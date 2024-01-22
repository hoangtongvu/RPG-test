using Core.Item;
using System;
using UnityEngine;

namespace Core.Inventory
{
    [Serializable]
    public class InventoriedItemAdder
    {
        [SerializeField] private Inventory inventory;

        public InventoriedItemAdder(Inventory inventory)
        {
            this.inventory = inventory;
        }

        public virtual bool AddItem(InventoriedItem inventoriedItem)
        {
            int addCount = inventoriedItem.itemCount;
            ItemProfileSO itemProfile = inventoriedItem.ItemProfile;
            ItemCode itemCode = itemProfile.itemCode;
            ItemType itemType = itemProfile.itemType;

            if (itemType == ItemType.Equipment) return this.AddEquipment(inventoriedItem);
            return AddItem(itemCode, addCount);
        }

        public virtual bool AddEquipment(InventoriedItem itemPicked)
        {
            if (this.inventory.IsInventoryFull()) return false;
            InventoriedItem item = itemPicked.Clone();
            this.inventory.Items.Add(item);
            return true;
        }

        public virtual bool AddItem(ItemCode itemCode, int addCount)//Add resourse item, not equipment
        {
            ItemProfileSO itemProfile = this.inventory.GetItemProfile(itemCode);

            int addRemain = addCount;
            int newCount;
            int itemMaxStack;
            int addMore;
            InventoriedItem itemExist;
            for (int i = 0; i < this.inventory.MaxSlot; i++)
            {
                itemExist = this.inventory.GetItemNotFullStack(itemCode);
                if (itemExist == null)
                {
                    if (this.inventory.IsInventoryFull()) return false;
                    itemExist = this.inventory.CreateEmptyItem(itemProfile);
                    this.inventory.Items.Add(itemExist);
                }

                newCount = itemExist.itemCount + addRemain;
                itemMaxStack = this.inventory.GetMaxStack(itemExist);

                if (newCount > itemMaxStack)
                {
                    addMore = itemMaxStack - itemExist.itemCount;
                    newCount = itemExist.itemCount + addMore;
                    addRemain -= addMore;
                }
                else
                {
                    addRemain -= newCount;
                }

                itemExist.itemCount = newCount;
                if (addRemain < 1) break;

            }

            return true;
        }

    }
}
