using Core;
using Core.Animator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Player
{
    public class AttackHandler : SaiMonoBehaviour
    {
        [SerializeField] private Ctrl ctrl;
        [SerializeField] private Transform weaponHitbox;


        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCtrl(ref this.ctrl);
        }



        public void DisableWeaponCollider()
        {
            this.ctrl.WeaponHolder.Weapon.DisableWeaponCollider();
            //Debug.Log("weap disabled");
        }

        public void EnableWeaponCollider()
        {
            this.ctrl.WeaponHolder.Weapon.EnableWeaponCollider();
            //Debug.Log("weap enabled");
        }

    }

}
