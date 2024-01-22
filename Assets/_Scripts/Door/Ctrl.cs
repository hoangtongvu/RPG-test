using Core;
using UnityEngine;

namespace Door
{
    public class Ctrl : SaiMonoBehaviour
    {
        [SerializeField] private Transform hinge;
        [SerializeField] private DoorStateManager doorStateManager;

        public Transform Hinge => hinge;
        public DoorStateManager DoorStateManager => doorStateManager;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadComponentInChildren(ref this.doorStateManager);
            this.LoadHinge();
        }

        private void LoadHinge()
        {
            this.hinge = transform.Find("Hinge");
        }
    }
}