

using System.Collections.Generic;

namespace Map
{
    internal abstract class EnvironmentPainter
    {
        protected List<TypeEnvironment> typeEnvironments = new List<TypeEnvironment>();
        protected List<Environment> environments = new List<Environment>();
        public EnvironmentTransform CurrentTransform { get; protected set; }
        public EnvironmentTransform NextTransform { get; protected set; }
        public abstract void CreateEnvironment(EnvironmentTransform startTransform);
        public abstract void ClearEnvironment();

    }
}
