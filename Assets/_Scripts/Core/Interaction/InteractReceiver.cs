using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.Interaction
{
    [RequireComponent(typeof(SphereCollider))]
    public abstract class InteractReceiver : SaiMonoBehaviour
    {

        public abstract void OnInteract();

    }
}