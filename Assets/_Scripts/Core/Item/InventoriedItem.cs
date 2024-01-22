using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.Item
{

    [System.Serializable]
    public class InventoriedItem
    {
        public ItemProfileSO ItemProfile;
        public int itemCount = 0;
        public int maxStack = 7;

        public virtual InventoriedItem Clone()
        {
            InventoriedItem item = new()
            {
                ItemProfile = this.ItemProfile,
                itemCount = this.itemCount,
                maxStack = this.maxStack,
            };
            return item;
        }
    }
}