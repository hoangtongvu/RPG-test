using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyCamera
{
    public class CameraHolder : SaiMonoBehaviour
    {
        private static CameraHolder instance;

        //public static CameraHolder Instance => instance;
        public static CameraHolder Instance
        {
            get 
            {
                if (instance == null) instance = FindObjectOfType<CameraHolder>();
                return instance;
            }
        }

        [SerializeField] private Camera mainCam;
        public Camera MainCam => mainCam;

        protected override void Awake()
        {
            base.Awake();
            if (instance == null) instance = this;
            else
            {
                Destroy(gameObject);
                Debug.LogError("there is 2 instance.", this.gameObject);
            }
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadMainCam();
        }

        private void LoadMainCam()
        {
            this.mainCam = transform.Find("Main Camera").GetComponent<Camera>();
        }
    }
}