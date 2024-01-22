using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Entity
{
    public class Ctrl: SaiMonoBehaviour
    {

        [SerializeField] private List<UnityEngine.Object> components;
        [SerializeField] private Rigidbody rb;
        public Rigidbody Rb => rb;



        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadComponentInChildren(ref this.rb);

            this.components.Clear();
            this.components.Add(this.rb);
        }

        public T GetComponentOfType<T>() where T : UnityEngine.Object
        {
            foreach (UnityEngine.Object component in this.components)
            {
                if (component.GetType() == typeof(T)) return (T)component;
            }
            return null;

        }


    }

}
