using System.Collections.Generic;
using UnityEngine;

namespace Map.EnvironmentTemplate
{
    internal class FourEnvironmentMaterial : EnvironmentPainter
    {
        public FourEnvironmentMaterial(TypeEnvironment type1, TypeEnvironment type2, TypeEnvironment type3, TypeEnvironment type4)
        {
            typeEnvironments.Add(type1);
            typeEnvironments.Add(type2);
            typeEnvironments.Add(type3);
            typeEnvironments.Add(type4);
        }
        public override void ClearEnvironment()
        {
            foreach (var env in environments)
            {
                MonoBehaviour.Destroy(env.gameObject);
            }    
        }

        public override void CreateEnvironment(EnvironmentTransform startTransform)
        {
            CurrentTransform = startTransform;
            NextTransform = MaterialEnvironmentControl.Intanse.GetNextEnvironmentTransformRow(CurrentTransform);
            environments.Add(MaterialEnvironmentControl.Intanse.CreateEnvironment(CurrentTransform, typeEnvironments[0]));
            for(int i =1;i< typeEnvironments.Count; i++)
            {
                environments.Add(MaterialEnvironmentControl.Intanse.CreateEnvironment(environments[i - 1].GetNextPosition(), typeEnvironments[i]));
            }
        }
    }
}
