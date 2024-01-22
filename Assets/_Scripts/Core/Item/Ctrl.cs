using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.Item
{
    public class Ctrl : SaiMonoBehaviour
    {


        [SerializeField] protected ItemDespawner itemDespawner;
        [SerializeField] protected InventoriedItem inventoriedItem;

        public ItemDespawner ItemDespawner => itemDespawner;
        public InventoriedItem InventoriedItem => inventoriedItem;


        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadItemDespawner();
            this.LoadInventoriedItem();
        }


        protected virtual void LoadItemDespawner() => this.itemDespawner = GetComponentInChildren<ItemDespawner>();


        public virtual void SetInventoriedItem(InventoriedItem _itemInventory) => this.inventoriedItem = _itemInventory.Clone();


        protected virtual void LoadInventoriedItem()
        {
            if (this.inventoriedItem.ItemProfile != null) return;
            ItemCode itemCode = EnumExtensions.FromString<ItemCode>(transform.name);
            ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
            this.inventoriedItem.ItemProfile = itemProfile;
            this.ResetItem();

        }

        protected virtual void OnEnable() => this.ResetItem();

        protected virtual void ResetItem() => this.inventoriedItem.itemCount = 1;

    }

}