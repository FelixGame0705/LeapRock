using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    internal class MaterialEnvironmentControl : MonoBehaviour
    {
        public static MaterialEnvironmentControl Intanse;
        [SerializeField] Transform _groupEnvironment;
        [SerializeField] List<Environment> _environmentPrefabs;
        [SerializeField] float _environmentSize = 1f;
        [SerializeField] float _spaceEnvironment = 0.1f;

        private void Awake()
        {
            Intanse = this;
        }

        private Environment TakeEnvironmentMaterial(TypeEnvironment type)
        {
            return _environmentPrefabs.Find(x => x.GetTypeEnvironment() == type);
        }

        public Environment CreateEnvironment(EnvironmentTransform spawnPos,TypeEnvironment type)
        {
            Environment environment = Instantiate(TakeEnvironmentMaterial(type),_groupEnvironment);
            environment.SetSize(_environmentSize);
            environment.SetCurrentPosition(spawnPos);
            environment.SetNextPosition(GetNextEnvironmentTransformCow(spawnPos));
            return environment;
        }

        public EnvironmentTransform GetNextEnvironmentTransformCow(EnvironmentTransform currenPosion)
        {
            return new EnvironmentTransform(currenPosion.x + 1, currenPosion.y, currenPosion.position + Vector3.right * (_environmentSize + _spaceEnvironment));
        }

        public EnvironmentTransform GetNextEnvironmentTransformRow(EnvironmentTransform currenPosion)
        {
            return new EnvironmentTransform(currenPosion.x , currenPosion.y+1, currenPosion.position + Vector3.forward * (_environmentSize + _spaceEnvironment));
        }
    }
}
