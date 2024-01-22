using Core;
using Core.Object;
using UnityEngine;

namespace Core
{
    public  class HPTextFollowTarget : ObjFollowTargetPos
    {
        [SerializeField] private Transform target;
        [SerializeField] private float addingY;

        public void SetTarget(Transform target) => this.target = target;

        protected override Vector3 GetTargetPos()
        {
            return this.target.position.Add(y : this.addingY);
        }


    }
}