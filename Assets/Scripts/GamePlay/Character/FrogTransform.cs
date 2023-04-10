using Entity;
namespace Character
{
    internal class FrogTransform : TransformComponent
    { 
        public override void InitComponent(EnityControl enityControl)
        {
            
        }
        private void Start()
        {
            _currentTransform = Map.MaterialEnvironmentControl.Intanse.GetNextEnvironmentTransformColRight(_currentTransform);
            this.transform.position = _currentTransform.position + UnityEngine.Vector3.up;
        }
    }
}
