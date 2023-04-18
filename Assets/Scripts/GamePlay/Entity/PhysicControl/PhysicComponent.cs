using UnityEngine;
namespace Entity
{
    internal abstract class PhysicComponent : EntityComponent
    {
        [SerializeField] protected Rigidbody _body;

        public Rigidbody GetRigidbody() => _body;
    }
}
