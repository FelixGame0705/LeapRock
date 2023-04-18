using UnityEngine;
using Map;
namespace Entity
{
    internal class MoveRightOnFly : IAction
    {
        TransformComponent _transformComponent;
        Transform _transform;
        EnvironmentTransform _environmentTransformNext;
        Vector3 nextPosition;
        Vector3 none;
        float _distaneMove;
        float speed = 2.5f;
        System.Action _onEndAction;
        bool isSetupValue;
        float _startHeight;
        public MoveRightOnFly(TransformComponent transformComponent, System.Action onEndAction)
        {
            _transformComponent =  transformComponent;
            _transform = transformComponent._transform;
            _onEndAction = onEndAction;
            isSetupValue = true;
        }
        public void DoAction()
        {
            SetValue();
            OnMove();
        }
        public void SetValue()
        {
            if (isSetupValue== true)
            {
                isSetupValue = false;
                _environmentTransformNext = MaterialEnvironmentControl.Intanse.GetNextEnvironmentTransformColRight(MaterialEnvironmentControl.Intanse.GetNextEnvironmentTransformRow(_transformComponent._currentTransform));
                none = new Vector3(_transform.position.x, 0f, _transform.position.z) + Vector3.up;
                nextPosition = _environmentTransformNext.position + Vector3.up;
                _startHeight = _transform.position.y;
                _distaneMove = Vector3.Distance(none, nextPosition);
            }

        }

        public void OnMove()
        {
            if (none == nextPosition)
            {
                OnEndMove();
                return;
            }
            none = Vector3.MoveTowards(none, nextPosition, speed * Time.deltaTime);
            _transform.position = new Vector3(none.x, GetHeighMove(),none.z) + Vector3.up;
            Debug.Log(none);
        }

        float GetHeighMove()
        {
            float x =_distaneMove- Vector3.Distance(none, nextPosition);
            return (-_startHeight * x * x) / (_distaneMove * _distaneMove) + _startHeight;
        }

        void OnEndMove()
        {
            _transformComponent.SetCurrentTransform(_environmentTransformNext);
            Map.MapControl.Instance.SpawnNext(_transformComponent._currentTransform);
            isSetupValue = true;
            _onEndAction.Invoke();
        }
    }
}
