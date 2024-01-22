using Core.MyEvent;
using System;
using UnityEngine;

namespace Core.Interaction
{
    public abstract class InteractInput : SaiMonoBehaviour
    {
        //public readonly CustomEventNoArg onInteractTriggerEvent = new();
        [SerializeField] protected InteractSender interactSender;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadInteractSender();
        }

        void LoadInteractSender() => this.interactSender = GetComponent<InteractSender>();

        protected abstract void InputHandling();
    }
}
