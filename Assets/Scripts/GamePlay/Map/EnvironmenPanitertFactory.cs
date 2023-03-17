using Map.EnvironmentTemplate;
using System.Collections.Generic;

namespace Map
{
    internal class EnvironmenPanitertFactory : IEnvironmentPainterFactory
    {
        public EnvironmentPainter CreateEnvironmentPainter(int random)
        {
            switch(random)
            {
                case 1:
                    return new FourEnvironmentMaterial(TypeEnvironment.Ground, TypeEnvironment.Ground, TypeEnvironment.Ground, TypeEnvironment.Ground);
                case 2:
                    return new FourEnvironmentMaterial(TypeEnvironment.Water, TypeEnvironment.Ground, TypeEnvironment.Ground, TypeEnvironment.Ground);
                case 3:
                    return new FourEnvironmentMaterial(TypeEnvironment.Ground, TypeEnvironment.Water, TypeEnvironment.Ground, TypeEnvironment.Ground);
                case 4:
                    return new FourEnvironmentMaterial(TypeEnvironment.Ground, TypeEnvironment.Ground, TypeEnvironment.Water, TypeEnvironment.Ground);
                default:
                    return null;
            }
        }
    }
}
