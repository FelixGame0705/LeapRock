using Map;
using UnityEngine;

namespace Entity
{
    internal abstract class TransformComponent : EntityComponent
    {
        public EnvironmentTransform _currentTransform;
        public UnityEngine.Transform _transform;
        public EnvironmentTransform GetCurrentTransform() => _currentTransform;

        public void SetCurrentTransform(EnvironmentTransform environment)
            => _currentTransform = environment;
        public EnvironmentTransform GetNextTransform()
            => Map.MaterialEnvironmentControl.Intanse.GetNextEnvironmentTransformRow(_currentTransform);
        public EnvironmentTransform GetNextTransformColumnRight()
            => Map.MaterialEnvironmentControl.Intanse.GetNextEnvironmentTransformColRight(_currentTransform);
        public EnvironmentTransform GetNextTransformColumnLeft() 
            => Map.MaterialEnvironmentControl.Intanse.GetNextEnvironmentTransformColLeft(_currentTransform);
    }
}
