using Core;
using UnityEngine;

namespace Core.Object
{
    public class ObjFollowTargetTransform : SaiMonoBehaviour
    {
        [Header("Obj Follow Target")]
        [SerializeField] protected Transform target;


        protected virtual void LateUpdate() => this.FollowingTarget();


        protected virtual void FollowingTarget()
        {
            if (target == null)
            {
                Debug.LogWarning("No target at GameObject: " + gameObject.name);
                return;
            }
            this.FollowTarget();

        }
        protected virtual void FollowTarget()
        {
            transform.position = target.position;
            //transform.position = Vector3.Lerp(transform.position, this.target.position, 0.5f);

        }

        public virtual void SetTarget(Transform target) => this.target = target;


    }
}