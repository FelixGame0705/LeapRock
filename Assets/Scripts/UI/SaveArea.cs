using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI
{
    public class SaveArea:MonoBehaviour
    {
        RectTransform rectTransform;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            UpdateSaveArea(Screen.safeArea);
        }

        private void UpdateSaveArea(Rect saveArea)
        {
            Vector2 minAnchor = saveArea.position;
            Vector2 maxAnchor = saveArea.position + saveArea.size;
            minAnchor.x /= Screen.width;
            minAnchor.y /= Screen.height;
            maxAnchor.x /= Screen.width;
            maxAnchor.y /= Screen.height;

            rectTransform.anchorMin = minAnchor;
            rectTransform.anchorMax = maxAnchor;
        }
    }
}
