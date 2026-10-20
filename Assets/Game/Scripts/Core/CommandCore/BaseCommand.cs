using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Game.Scripts.Core.CommandCore
{
    public abstract class BaseCommand : ICommand
    {
        public bool IsCompleted { get; set; }

        public virtual void Start() { }

        public virtual void Update() { }

        protected void Complete()
        {
            if (IsCompleted) return;

            IsCompleted = true;

            OnComplete();
        }

        protected virtual void OnComplete() { }
    }
}
