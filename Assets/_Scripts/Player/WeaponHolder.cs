using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class WeaponHolder : SaiMonoBehaviour
    {
        [SerializeField] private Weapon weapon;

        public Weapon Weapon => weapon;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadComponentInChildren(ref this.weapon);
        }

    }
}