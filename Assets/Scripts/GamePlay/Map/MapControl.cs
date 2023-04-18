using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    internal class MapControl : MonoBehaviour
    {
        public static MapControl Instance;
        [SerializeField] List<SegmentEnvironment> segmentEnvironments;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            foreach(SegmentEnvironment env in segmentEnvironments)
            {
                env.CreateSegment();
            }
            SetPosition();
        }

        IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(2);
                SegmentEnvironment first = segmentEnvironments[0];
                segmentEnvironments.RemoveAt(0);
                first.TurnOn(segmentEnvironments[segmentEnvironments.Count - 1].NextStartSegment);
                segmentEnvironments.Add(first);

            }
        }

        public void SpawnNext(EnvironmentTransform environmentTransform)
        {
            if(segmentEnvironments[segmentEnvironments.Count - 1].NextStartSegment.y - environmentTransform.y < 8)
            {
                SegmentEnvironment first = segmentEnvironments[0];
                segmentEnvironments.RemoveAt(0);
                first.TurnOn(segmentEnvironments[segmentEnvironments.Count - 1].NextStartSegment);
                segmentEnvironments.Add(first);
            }
        }

        void SetPosition()
        {
            segmentEnvironments[0].TurnOn(new EnvironmentTransform(0, 0, Vector3.zero));
            for(int i =1; i< segmentEnvironments.Count; i++)
            {
                segmentEnvironments[i].TurnOn(segmentEnvironments[i - 1].NextStartSegment);
            }
        }

    }
}
