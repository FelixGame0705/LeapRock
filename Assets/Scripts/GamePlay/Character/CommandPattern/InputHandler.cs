using CommandPattern;
using Entity;
using Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class InputHandler : MonoBehaviour
{
    private Command buttonA;
    private Command buttonD;
    [SerializeField] private TransformComponent _transformComponent;
    [SerializeField] private SegmentEnvironment sizeMap;

    bool isPressBtnA = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Press A");
            buttonA = new CommandMoveLeft(_transformComponent, sizeMap.GetSizeSegment());
            buttonA.Execute();
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Press D");
            buttonD = new CommandMoveRight(_transformComponent, sizeMap.GetSizeSegment());
            buttonD.Execute();
        }
    }

}
