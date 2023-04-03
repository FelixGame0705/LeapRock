using UnityEngine;

namespace Entity
{
    internal abstract class EntityComponent : MonoBehaviour
    {
        public abstract void InitComponent(EnityControl enityControl);
    }
}
