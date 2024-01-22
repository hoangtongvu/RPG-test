using MyCamera;
using UnityEngine;

namespace Core.Object
{
    public class ObjLookAtCamera : SaiMonoBehaviour
    {
        [SerializeField] private Camera mainCam;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCamera();
        }

        private void LoadCamera()
        {
            this.mainCam = CameraHolder.Instance.MainCam;
        }

        protected override void ResetValue()
        {
            base.ResetValue();
            this.BillBoarding();
        }

        private void BillBoarding()
        {
            transform.LookAt(transform.position + this.mainCam.transform.forward);
        }
    }
}