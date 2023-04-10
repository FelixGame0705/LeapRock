using UnityEngine;
namespace Entity
{
    internal class JumpNormal : IAction
    {
        AnimationCurve quydao;
        TransformComponent transformComponent;
        Transform transform;
        Vector3 nextPosition;
        Vector3 none;
        float speed = 2.5f;
        float x = 0;
        float y = 0;
        System.Action action;
        bool isSetupValue;
        public JumpNormal(TransformComponent _transformComponent, AnimationCurve _quydao, System.Action callback)
        {
            transformComponent = _transformComponent;
            transform = _transformComponent._transform;
            action = callback;
            quydao = _quydao;
        }

        public void DoAction()
        {
            SetUpValue();
            Move();
        }

        void Move()
        {
            if (none == nextPosition)
            {
                OnEndJump();
                return;
            }
            none = Vector3.MoveTowards(none, nextPosition, speed * Time.deltaTime);
            x += speed * Time.deltaTime;
            y = quydao.Evaluate(x);
            transform.position = none + Vector3.up * y;
        }

        void SetUpValue()
        {
            if(isSetupValue == true)
            {
                transform.position = transformComponent.GetCurrentTransform().position + Vector3.up;
                nextPosition = transformComponent.GetNextTransform().position + Vector3.up;
                none = transform.position;
                x = 0;
                isSetupValue = false;
                //Debug.Log(transform.position + " And " + nextPosition);
            }
        }

        void OnEndJump()
        {
            transformComponent.SetCurrentTransform(transformComponent.GetNextTransform());
            Map.MapControl.Instance.SpawnNext(transformComponent._currentTransform);
            isSetupValue = true;
            action.Invoke();
        }
    }
}
