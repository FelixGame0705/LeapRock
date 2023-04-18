using UnityEngine;
using System.Collections.Generic;
namespace Map
{
    [CreateAssetMenu(fileName = "Segment Environment Template", menuName = "Create Segment", order = 1)]
    internal class SegmentEnvironmentTemplate : ScriptableObject
    {
        public List<TypeEnvironment> typeEnvironments;
    }
}
