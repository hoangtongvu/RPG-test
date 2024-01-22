using Core;
using UnityEngine;

namespace Door
{
    public class DoorStateManager : SaiMonoBehaviour
    {
        [SerializeField] private Ctrl ctrl;
        [SerializeField] private DoorState doorState = DoorState.Closed;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCtrl(ref this.ctrl);
        }


        public void ToggleDoor()
        {
            switch (this.doorState)
            {
                case DoorState.Open:
                    this.CloseDoor();
                    break;
                case DoorState.Closed:
                    this.OpenDoor();
                    break;
                default:
                    break;
            }

        }

        public void OpenDoor()
        {
            this.doorState = DoorState.Open;
            transform.parent.eulerAngles = new Vector3(0, -90, 0);
        }

        public void CloseDoor()
        {
            this.doorState = DoorState.Closed;
            transform.parent.eulerAngles = new Vector3(0, 0, 0);
        }

    }
}