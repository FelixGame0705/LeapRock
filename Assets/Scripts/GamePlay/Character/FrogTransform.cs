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
            _currentTrainform = Map.MaterialEnvironmentControl.Intanse.GetNextEnvironmentTransformCol(_currentTrainform);
            this.transform.position = _currentTrainform.position + UnityEngine.Vector3.up;
        }
    }
}
