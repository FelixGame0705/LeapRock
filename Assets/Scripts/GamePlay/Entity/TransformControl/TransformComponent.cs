using Map;
namespace Entity
{
    internal abstract class TransformComponent : EntityComponent
    {
        public EnvironmentTransform _currentTrainform;
        public UnityEngine.Transform _transform;
        public EnvironmentTransform GetCurrentTransform() => _currentTrainform;

        public void SetCurrentTransform(EnvironmentTransform environment)
            => _currentTrainform = environment;
        public EnvironmentTransform GetNextTransform()
            => Map.MaterialEnvironmentControl.Intanse.GetNextEnvironmentTransformRow(_currentTrainform);

    }
}
