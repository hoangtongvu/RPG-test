using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerJumping : SaiMonoBehaviour
    {

        [SerializeField] private Ctrl ctrl;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float jumpForce = 10f;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCtrl(ref ctrl);
            this.rb = this.ctrl.GetComponentOfType<Rigidbody>();
        }

        private void Update()
        {
            this.Jumping();
        }

        private void Jumping()
        {
            InputManager input = InputManager.Instance;
            if (!input.SpacePressed) return;
            this.Jump(this.jumpForce);
        }

        private void Jump(float force)
        {
            this.rb.AddForce(new Vector3(0f, force, 0f), ForceMode.Impulse);
        }
    }

}
