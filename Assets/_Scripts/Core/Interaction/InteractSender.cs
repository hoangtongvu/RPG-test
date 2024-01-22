using Core.Interaction.ActionHandler;
using Core.MyEvent;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interaction
{

    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(InteractInput))]
    public class InteractSender : SaiMonoBehaviour
    {

        [SerializeField] private int interactableCount = 0;
        [SerializeField] private float sphereRadius = 3f;
        [SerializeField] private List<InteractReceiver> interactables;
        [SerializeField] private SphereCollider sphereCollider;
        [SerializeField] private InteractReceiver currentInteractableReceiver = null;
        [SerializeField] private List<InteractActionHandler> extendedActions;

        public readonly CustomEventNoArg onEmptyReceivers = new();
        public readonly CustomEventNoArg onNotEmptyReceivers = new();


        protected override void ResetValue()
        {
            base.ResetValue();
            this.sphereCollider.radius = this.sphereRadius;
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadComponentInCtrl(ref this.sphereCollider);
            this.LoadExtendedActions();
        }
        void LoadExtendedActions()
        {
            InteractActionHandler[] handlers = GetComponents<InteractActionHandler>();
            this.extendedActions.AddRange(handlers);
        }


        private void SetInteractReceiversCount(int value)
        {
            this.interactableCount = value;

            if (value == 0) this.onEmptyReceivers.Invoke();
            else this.onNotEmptyReceivers.Invoke();
        }

        public void Interact()
        {
            if (this.interactableCount == 0) return;

            InteractReceiver interactReceiver = this.GetNearestReceiver(this.interactables);
            this.currentInteractableReceiver = interactReceiver;

            foreach (var interactAction in this.extendedActions)
            {
                if (interactAction.PerformAction(interactReceiver)) return;
            }
            interactReceiver.OnInteract();
        }

        private void OnTriggerEnter(Collider other) => this.TryAddInteractable(other);

        private void OnTriggerExit(Collider other) => this.TryRemoveInteractable(other);

        private void TryAddInteractable(Collider other)
        {
            if (!other.transform.TryGetComponent(out InteractReceiver interactReceiver)) return;
            interactables.Add(interactReceiver);
            this.SetInteractReceiversCount(this.interactableCount + 1);
        }

        private void TryRemoveInteractable(Collider other)
        {
            for (int i = 0; i < this.interactableCount; i++)
            {
                InteractReceiver receiver = this.interactables[i];
                if (receiver.transform != other.transform) continue;
                this.interactables.RemoveAt(i);
                this.SetInteractReceiversCount(this.interactableCount - 1);
            }
        }

        private InteractReceiver GetNearestReceiver(List<InteractReceiver> interacts)
        {
            int length = interacts.Count;


            float minDistance = Vector3.Distance(this.transform.position, interacts[0].transform.position);
            int minDistanceIndex = 0;

            for (int i = 1; i < length; i++)
            {
                float dis = Vector3.Distance(this.transform.position, interacts[i].transform.position);
                if (minDistance > dis)
                {
                    minDistance = dis;
                    minDistanceIndex = i;
                }
            }

            return interacts[minDistanceIndex];

        }





    }




}