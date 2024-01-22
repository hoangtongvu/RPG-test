using System;

namespace Core.MyEvent
{
    public class CustomEventNoArg
    {
        protected event Action action;

        public virtual void Invoke()
        {
            action?.Invoke();
        }

        public virtual void AddListener(Action call)
        {
            action += call;
        }

        public virtual void RemoveListener(Action call)
        {
            action -= call;
        }
    }
}