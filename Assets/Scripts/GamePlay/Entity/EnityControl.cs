
using UnityEngine;
using System.Collections.Generic;
namespace Entity
{
    internal abstract class EnityControl : MonoBehaviour
    {
        [SerializeField] protected List<EntityComponent> _entityComponents;
        public virtual T GetEntityComponent<T>() where T : EntityComponent
        {
            foreach (var component in _entityComponents)
            {
                if (component is T) return component as T;
            }
            return null;
        }

        protected void InitComponent()
        {
            foreach(var component in _entityComponents)
            {
                component.InitComponent(this);
            }
        }
    }
}
