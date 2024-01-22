using Core;
using System;
using UnityEngine;

namespace Core.Interaction
{
    [RequireComponent(typeof(InteractSender))]
    public class InteractInputByKey : InteractInput
    {
        private void OnEnable() => this.InputHandling();
        protected override void InputHandling() => this.SubEvent();


        private void SubEvent()
        {
            InputManager inputManager = InputManager.Instance;
            inputManager.onInteractKeyPressed.AddListener(this.interactSender.Interact);
        }
    }
}