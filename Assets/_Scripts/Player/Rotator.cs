using Core;
using MyCamera;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Rotator : SaiMonoBehaviour
    {

        [SerializeField] private Ctrl ctrl;
        [SerializeField] private float rotateSpeed = 5f;


        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCtrl(ref ctrl);

        }

        private void FixedUpdate()
        {
            this.RotateParentTowardMouse();
        }

        private void RotateParentTowardMouse()
        {
            Camera mainCam = CameraHolder.Instance.MainCam;

            Vector2 playerPosOnScreen = mainCam.WorldToScreenPoint(transform.parent.position);
            Vector2 mousePosOnScreen = Input.mousePosition;
            Vector2 lookDir2D = (mousePosOnScreen - playerPosOnScreen).normalized;

            Vector3 lookDir3D = new(lookDir2D.x, 0f, lookDir2D.y);


            Vector3 newDirection = Vector3.Lerp(transform.parent.forward, lookDir3D, rotateSpeed * Time.fixedDeltaTime);
            transform.parent.rotation = Quaternion.LookRotation(newDirection);
        }

    }

}
