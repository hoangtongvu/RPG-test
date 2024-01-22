using Core;
using Core.Object;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UI.Text
{
    public class HPText : BaseText
    {
        [field: SerializeField] public HPTextFollowTarget HPTextFollowTarget { get; private set; }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadObjFollow();
        }

        void LoadObjFollow() => this.HPTextFollowTarget = GetComponent<HPTextFollowTarget>();

        public void SetHP((int currentHp, int maxHp) wrapper)
        {
            this.text.text = wrapper.currentHp + "/" + wrapper.maxHp;
        }

        public void SetTarget(Transform target) => this.HPTextFollowTarget.SetTarget(target);
    }
}