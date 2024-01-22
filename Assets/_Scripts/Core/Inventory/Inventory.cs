using Core.Item;
using System.Collections.Generic;
using UnityEngine;


namespace Core.Inventory
{

    public class Inventory : SaiMonoBehaviour
    {
        [SerializeField] protected int maxSlot = 10;
        [SerializeField] protected List<InventoriedItem> items;
        [SerializeField] private InventoriedItemAdder itemAdder;
        [SerializeField] private InventoriedItemDeductor itemDeductor;

        public int MaxSlot => maxSlot;
        public List<InventoriedItem> Items => items;
        public InventoriedItemAdder ItemAdder => itemAdder;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadItemAdder();
            this.LoadItemDeductor();
        }

        private void LoadItemAdder() => this.itemAdder = new(this);
        private void LoadItemDeductor() => this.itemDeductor = new(this);


        private void Start()
        {
            this.itemAdder.AddItem(ItemCode.Apple, 5);
            this.itemDeductor.DeductItem(ItemCode.Apple, 2);
        }


        public virtual bool IsInventoryFull() => this.items.Count >= this.maxSlot;

        public virtual InventoriedItem GetItemNotFullStack(ItemCode itemCode)//NEW
        {
            foreach (InventoriedItem inventoriedItem in items)
            {
                if (inventoriedItem.ItemProfile.itemCode != itemCode) continue;
                if (this.IsFullStack(inventoriedItem)) continue;
                return inventoriedItem;
            }
            return null;
        }

        protected virtual bool IsFullStack(InventoriedItem inventoriedItem)//NEW
        {
            if (inventoriedItem == null) return true;

            int maxStack = this.GetMaxStack(inventoriedItem);
            return inventoriedItem.itemCount >= maxStack;
        }

        public virtual InventoriedItem CreateEmptyItem(ItemProfileSO itemProfile)//NEW
        {

            InventoriedItem inventoriedItem = new()
            {
                ItemProfile = itemProfile,
                maxStack = itemProfile.defaultMaxStack
            };
            return inventoriedItem;
        }


        public virtual int GetMaxStack(InventoriedItem inventoriedItem)//NEW
        {
            if (inventoriedItem == null) return 0;
            return inventoriedItem.maxStack;
        }

        public ItemProfileSO GetItemProfile(ItemCode itemCode)//NEW
        {
            var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
            foreach (ItemProfileSO profile in profiles) if (profile.itemCode == itemCode) return profile;
            return null;
        }


        public virtual bool ItemCheck(ItemCode itemCode, int numberCheck)
        {
            int totalCount = this.ItemTotalCount(itemCode);
            return totalCount >= numberCheck;
        }

        public virtual int ItemTotalCount(ItemCode itemCode)
        {
            int totalCount = 0;
            foreach (InventoriedItem inventoriedItem in items)
            {
                if (inventoriedItem.ItemProfile.itemCode != itemCode) continue;
                totalCount += inventoriedItem.itemCount;
            }
            return totalCount;
        }

        public virtual void ClearItemSlot()
        {
            InventoriedItem inventoriedItem;
            for (int i = 0; i < this.items.Count; i++)
            {
                inventoriedItem = this.items[i];
                if (inventoriedItem.itemCount == 0)
                {
                    this.items.RemoveAt(i);
                    i--;
                }
            }
        }



    }
}