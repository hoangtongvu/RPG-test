using Core.MyEvent;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Core
{

    public class InputManager : SaiMonoBehaviour
    {
        private static InputManager instance;
        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<InputManager>();
                    if (instance == null)
                    {
                        Debug.LogError("There is no instance");
                    }
                }

                return instance;
            }
        }

        [SerializeField] protected Camera mainCam;

        [SerializeField] private Vector3 mouseWorldPos;
        [SerializeField] protected MoveDirection moveDirection;
        [SerializeField] protected float onFiring = 0;
        [SerializeField] protected bool spacePressed = false;
        [SerializeField] protected bool enterPressed = false;
        [SerializeField] protected bool escapePressed = false;

        public readonly CustomEventNoArg onInteractKeyPressed = new();
        public readonly CustomEventNoArg onLeftMousePressed = new();


        public Vector3 MouseWorldPos => mouseWorldPos;
        public MoveDirection MoveDirection => moveDirection;

        public float OnFiring => onFiring;
        public bool SpacePressed => spacePressed;
        public bool EnterPressed => enterPressed;
        public bool EscapePressed => escapePressed;


        protected override void Awake()
        {
            if (instance != this)
            {
                Destroy(instance);
                instance = this;
                Debug.Log($"There is 2 instances of {GetType()}");
            }
        }

        private void FixedUpdate()
        {
            this.GetMousePos();
        }

        private void Update()
        {
            this.GetDirectionByKeyDown();
            this.GetMouseDown();
            this.GetSpaceKeyDown();
            this.GetEnterKeyDown();
            this.GetEscapeKeyDown();
            this.GetInteractDown();
        }


        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadMainCamera();
        }

        protected virtual void LoadMainCamera()
        {
            mainCam = GameObject.Find("Camera Holder").transform.Find("Main Camera").GetComponent<Camera>();
        }

        protected virtual void GetMousePos()
        {
            /* Note
             * When Using a 3D Perspective Camera you must set the Z 
             * value of Input.MousePosition to a positive value (such as the Camera’s Near Clip Plane) 
             * before passing it into ScreenToWorldPoint. If you don’t, no movement will be detected.
            */

            this.mouseWorldPos = Input.mousePosition;
            this.mouseWorldPos.z = 10;
            this.mouseWorldPos = mainCam.ScreenToWorldPoint(this.mouseWorldPos);

            Vector3 camPos = this.mainCam.transform.position;
            Vector3 dir = this.mouseWorldPos - camPos;
            Debug.DrawRay(camPos, dir, Color.blue);

        }

        protected virtual void GetDirectionByKeyDown()
        {
            this.moveDirection.up = Input.GetKey(KeyCode.W);
            this.moveDirection.down = Input.GetKey(KeyCode.S);
            this.moveDirection.left = Input.GetKey(KeyCode.A);
            this.moveDirection.right = Input.GetKey(KeyCode.D);
        }

        protected virtual void GetMouseDown()
        {
            this.onFiring = Input.GetAxis("Fire1");
            if (!Input.GetMouseButtonDown(0)) return;
            this.onLeftMousePressed.Invoke();
        }

        protected virtual void GetSpaceKeyDown()
        {
            this.spacePressed = false;
            this.spacePressed = Input.GetKeyDown(KeyCode.Space);
        }

        protected virtual void GetEnterKeyDown()
        {
            this.enterPressed = false;
            this.enterPressed = Input.GetKeyDown(KeyCode.Return);
        }

        protected virtual void GetEscapeKeyDown()
        {
            this.escapePressed = false;
            this.escapePressed = Input.GetKeyDown(KeyCode.Escape);
        }

        protected virtual void GetInteractDown()
        {
            if (!Input.GetKeyDown(KeyCode.E)) return;
            this.onInteractKeyPressed.Invoke();
        }
        




    }


}
