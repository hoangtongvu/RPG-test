using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Item
{

    [CreateAssetMenu(fileName = "ItemProfile", menuName = "SO/ItemProfile")]
    public class ItemProfileSO : ScriptableObject
    {
        public string itemName = "Item";
        public Sprite profilePicture;
        public ItemCode itemCode = ItemCode.NoItem;
        public ItemType itemType = ItemType.NoType;
        public int defaultMaxStack = 7;

        public static ItemProfileSO FindByItemCode(ItemCode itemCode)
        {
            var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
            foreach (ItemProfileSO profile in profiles)
            {
                if (profile.itemCode == itemCode) return profile;
            }
            return null;
        }

    }

}