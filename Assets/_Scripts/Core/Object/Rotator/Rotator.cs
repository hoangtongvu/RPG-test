using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Object.Rotator
{
    public class Rotator : SaiMonoBehaviour
    {

        [SerializeField] private Transform target;
        [SerializeField] private float rotateSpeed = 5f;

        private void FixedUpdate()
        {
            Vector3 originPos = transform.parent.position;
            Vector3 targetDirection = this.target.position - originPos;

            float singleStep = this.rotateSpeed * Time.fixedDeltaTime;

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            transform.parent.rotation = Quaternion.LookRotation(newDirection);
        }


    }

}
