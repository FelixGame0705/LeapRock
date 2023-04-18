using UnityEngine;
namespace Map
{
    [System.Serializable]
    internal struct EnvironmentTransform
    {
        public int x;
        public int y;
        public Vector3 position;

        public EnvironmentTransform(int _x, int _y, Vector3 _position)
        {
            x = _x;
            y = _y;
            position = _position;
        }
    }
}
