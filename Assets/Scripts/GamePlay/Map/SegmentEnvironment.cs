

using System.Collections.Generic;
using UnityEngine;
namespace Map
{
    [System.Serializable]
    internal class SegmentEnvironment : MonoBehaviour
    {
        [SerializeField] SegmentEnvironmentTemplate SegmentEnvironmentTemplate;
        List<Environment> environments;
        List<EnvironmentTransform> transformEnvironment;
        public EnvironmentTransform StartSegment { get; private set; }
        public EnvironmentTransform NextStartSegment { get; private set; }

        const int Col = 4;
        const int Row = 5;
        public void CreateSegment()
        {
            environments = new List<Environment>();
            transformEnvironment = new List<EnvironmentTransform>();
            foreach (var typeEvinronment in SegmentEnvironmentTemplate.typeEnvironments)
            {
                Environment env = MaterialEnvironmentControl.Intanse.CreateEnvironment(typeEvinronment);
                environments.Add(env);
            }
        }

        public void TurnOn(EnvironmentTransform startTransform) 
        {
            EnvironmentTransform nextOnCol = startTransform;
            EnvironmentTransform nextOnRow = startTransform;
            transformEnvironment.Clear();
            for (int i = 0; i < Row; i++)
            {
                transformEnvironment.Add(nextOnRow);
                for (int j=0; j< Col-1; j++)
                {
                    nextOnCol = MaterialEnvironmentControl.Intanse.GetNextEnvironmentTransformCol(nextOnCol);
                    transformEnvironment.Add(nextOnCol);
                }
                nextOnRow = MaterialEnvironmentControl.Intanse.GetNextEnvironmentTransformRow(nextOnRow);
                nextOnCol = nextOnRow;
            }
            StartSegment = startTransform;
            NextStartSegment = nextOnRow;
            for(int i=0; i< transformEnvironment.Count; i++)
            {
                environments[i].SetCurrentPosition(transformEnvironment[i]);
                environments[i].gameObject.SetActive(true);
            }
        }

        public void TurnOff()
        {
            for (int i = 0; i < transformEnvironment.Count; i++)
            {
                environments[i].gameObject.SetActive(false);
            }
        }
    }

}
