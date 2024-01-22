using Core;
using UnityEngine;

namespace Core.Object
{
    public class ObjFollowTargetAtRelativePosition : ObjFollowTargetTransform
    {

        [Header("Obj Follow Target At Fixed Distance")]
        [SerializeField] Vector3 distanceVector;

        private void OnEnable()
        {
            this.SetDistanceVector();
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.SetDistanceVector();

        }


        protected virtual void SetDistanceVector() => this.distanceVector = this.target.position - transform.position;


        protected override void FollowTarget()
        {
            base.FollowTarget();
            //transform.position = this.targetCam.position - this.distanceVector;
            transform.position -= this.distanceVector;

        }

    }
}