using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ScaleCaculator
    {
        private float scaleX = 0;
        private float scaleY = 0;
        public ScaleCaculator() { 
        }

        public float ScaleX
        {
            get { return scaleX; }
            set { 
                if(value > 0f)
                scaleX = value; 
            }
        }

        public float ScaleY
        {
            get { return scaleY; }
            set { 
                if(value > 0f)
                scaleY = value; 
            }
        }

        public void setScale(SizeStruct container, SizeStruct rescale)
        {
            ScaleX = scaleCalulator(container.width, rescale.width);
            ScaleY = scaleCalulator(container.height, rescale.height);
        }

        private float scaleCalulator(float containerSize, float itemSize)
        {
            return containerSize / itemSize;
        }
    }
}
