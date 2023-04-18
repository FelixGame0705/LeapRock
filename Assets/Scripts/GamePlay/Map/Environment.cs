using UnityEngine;
namespace Map
{
    internal abstract class Environment : MonoBehaviour
    {
        [SerializeField] protected TypeEnvironment _typeEnvironment;
        protected EnvironmentTransform currentPosition;
        protected EnvironmentTransform nextPosition;
        public TypeEnvironment GetTypeEnvironment() => _typeEnvironment;

        public void SetCurrentPosition(EnvironmentTransform position)
        {
            this.currentPosition = position;
            this.transform.position = currentPosition.position;
        }

        public void SetSize(float size) => this.transform.localScale = Vector3.one * size;

        public void SetNextPosition(EnvironmentTransform nextPosition) => this.nextPosition = nextPosition;

        public EnvironmentTransform GetNextPosition() => this.nextPosition;
        public EnvironmentTransform GetCurrentPosition() => this.currentPosition;
    }
}
