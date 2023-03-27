using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveArea : MonoBehaviour
{

    RectTransform rectTrans;
    Rect saveArea;
    Vector2 min;
    Vector2 max;
    UIDocument menuDoc;
    caculateLayout cl = new caculateLayout();
    private void Awake()
    {
        menuDoc = GetComponent<UIDocument>();
        VisualElement savearea = menuDoc.rootVisualElement.Q("savearea");
        updateLayout(savearea);
        savearea.style.marginLeft = cl.marginLeft;
        savearea.style.marginRight = cl.marginRight;
        savearea.style.marginTop = cl.marginTop;
        savearea.style.marginBottom = cl.marginBottom;
    }
    private void updateLayout(VisualElement temp)
    {
        var safeArea = Screen.safeArea;
        

        try
        {
            var leftTop = RuntimePanelUtils.ScreenToPanel(temp.panel,
                new Vector2(safeArea.xMin, Screen.height - safeArea.yMax));
            var rightBottom = RuntimePanelUtils.ScreenToPanel(temp.panel,
                new Vector2(Screen.width - safeArea.xMax, safeArea.yMin));

            cl.marginLeft = leftTop.x;
            cl.marginTop = leftTop.y;
            cl.marginRight = rightBottom.x;
            cl.marginBottom = rightBottom.y;
        }
        catch (InvalidCastException) { }
    }

    struct caculateLayout
    {
        public float marginLeft { get; set; }
        public float marginTop { get; set; }
        public float marginRight { get; set; }
        public float marginBottom { get; set; }
    }

}
