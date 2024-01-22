using Core.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Damage
{
    [RequireComponent(typeof(Collider))]

    public class DmgSender : SaiMonoBehaviour
    {

        [SerializeField] private Ctrl ctrl;
        [SerializeField] private int dmg = 10;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCtrl(ref this.ctrl);
        }

        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent(out DmgReceiver dmgReceiver);

            if (dmgReceiver == null) return;
            dmgReceiver.DeductHp(this.dmg);
        }

    }


}
