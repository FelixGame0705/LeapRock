using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    internal class MapControl : MonoBehaviour
    {
        IEnvironmentPainterFactory _environmentPainterFactory;
        List<EnvironmentPainter> _painters = new List<EnvironmentPainter>();

        private void Awake()
        {
            _environmentPainterFactory = new EnvironmenPanitertFactory();
        }
        private void Start()
        {

            EnvironmentPainter painter = _environmentPainterFactory.CreateEnvironmentPainter(1);
            painter.CreateEnvironment(new EnvironmentTransform(0,0,Vector3.zero));
            _painters.Add(painter);
            CreateEnvironment(1);
            CreateEnvironment(1);
            CreateEnvironment(1);
            CreateEnvironment(1);
            CreateEnvironment(1);
            CreateEnvironment(1);
            CreateEnvironment(1);
            CreateEnvironment(1);
            CreateEnvironment(1);
        }

        void CreateEnvironment(int random)
        {
            EnvironmentPainter painter = _environmentPainterFactory.CreateEnvironmentPainter(random);
            painter.CreateEnvironment(_painters[_painters.Count - 1].NextTransform);
            _painters.Add(painter);
        }
    }
}
