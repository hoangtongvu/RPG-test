using Core;
using UnityEngine;

namespace Core.Object
{
    public abstract class ObjFollowTargetPos : SaiMonoBehaviour
    {

        protected virtual void LateUpdate()
        {
            this.FollowingTarget();
        }


        protected virtual void FollowingTarget()
        {
            Vector3 targetPos = this.GetTargetPos();
            if (targetPos == default)
            {
                Debug.Log("Null TargetPos", this.gameObject);
                return;
            }
            this.transform.position = this.GetTargetPos();

        }


        protected abstract Vector3 GetTargetPos();


    }
}