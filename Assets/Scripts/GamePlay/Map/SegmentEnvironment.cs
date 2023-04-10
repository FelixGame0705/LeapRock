

using System.Collections.Generic;
using UnityEngine;
namespace Map
{
    [System.Serializable]
    internal class SegmentEnvironment : MonoBehaviour
    {
        [SerializeField] SegmentEnvironmentTemplate SegmentEnvironmentTemplate;
        [SerializeField] Vector2Int _sizeSegment; 
        List<Environment> _environments;
        List<EnvironmentTransform> _transformEnvironment;
        public EnvironmentTransform StartSegment { get; private set; }
        public EnvironmentTransform NextStartSegment { get; private set; }
        public void CreateSegment()
        {
            if(CheckSizeSegment() == false)
            {
                Debug.LogError("Khong cung so luong");
                return;
            }
            _environments = new List<Environment>();
            _transformEnvironment = new List<EnvironmentTransform>();
            foreach (var typeEvinronment in SegmentEnvironmentTemplate.typeEnvironments)
            {
                Environment env = MaterialEnvironmentControl.Intanse.CreateEnvironment(typeEvinronment);
                _environments.Add(env);
            }
        }

        public void TurnOn(EnvironmentTransform startTransform) 
        {
            SetPosition(startTransform);
            for (int i=0; i< _transformEnvironment.Count; i++)
            {
                _environments[i].SetCurrentPosition(_transformEnvironment[i]);
                _environments[i].gameObject.SetActive(true);
            }
        }

        public void TurnOff()
        {
            for (int i = 0; i < _transformEnvironment.Count; i++)
            {
                _environments[i].gameObject.SetActive(false);
            }
        }

        private void SetPosition(EnvironmentTransform startTransform)
        {
            EnvironmentTransform nextOnCol = startTransform;
            EnvironmentTransform nextOnRow = startTransform;
            _transformEnvironment.Clear();
            for (int i = 0; i < _sizeSegment.y; i++)
            {
                _transformEnvironment.Add(nextOnRow);
                for (int j = 0; j < _sizeSegment.x - 1; j++)
                {
                    nextOnCol = MaterialEnvironmentControl.Intanse.GetNextEnvironmentTransformColRight(nextOnCol);
                    _transformEnvironment.Add(nextOnCol);
                }
                nextOnRow = MaterialEnvironmentControl.Intanse.GetNextEnvironmentTransformRow(nextOnRow);
                nextOnCol = nextOnRow;
            }
            StartSegment = startTransform;
            NextStartSegment = nextOnRow;
        }

        private bool CheckSizeSegment()
        {
            return _sizeSegment.x * _sizeSegment.y == SegmentEnvironmentTemplate.typeEnvironments.Count;
        }

        public Vector2Int GetSizeSegment() => _sizeSegment;
    }

}
