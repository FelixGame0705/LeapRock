
using System.Collections.Generic;
using UnityEngine;
using Map;

namespace Entity
{
    /*Nhay len phia truoc*/
    internal class FrogJump : StateAction
    {
        TransformComponent _transformComponent;
        UnityEngine.AnimationCurve _trajectoryJump;
        Transform _frogTransform;
        EnvironmentTransform _targetMovement;

        Vector3 _nextPosition;
        Vector3 _shadowPostionOnGrid;

        float _distanceMovement;
        float _speed;
        public FrogJump(EnityControl enityControl, UnityEngine.AnimationCurve trajectoryJump) : base(enityControl)
        {
            _playAnimation = new PlayAnimationNormal();
            _trajectoryJump = trajectoryJump;
            _transformComponent = enityControl.GetEntityComponent<TransformComponent>();
            _frogTransform = _transformComponent._transform;
        }
        public override void EnterState()
        {
            
            base.EnterState();
            SetCurrentTransfrom();


        }

        public override void FixedUpdateState()
        {
            OnHandler();
            if(Input.GetKey(KeyCode.D))
            {
                _stateActionComponent.SwitchState(_stateActionComponent.GetSateAction("MoveRight"));
            }
            if (Input.GetKey(KeyCode.A))
            {
                _stateActionComponent.SwitchState(_stateActionComponent.GetSateAction("MoveLeft"));
            }
        }

        public override void OnHandler()
        {
            OnJump();
        }

        public override void UpdateSate()
        {
            
        }

        protected override void ExitState()
        {
            _stateActionComponent.SwitchState(_stateActionComponent.GetSateAction("Idle"));
        }

        void SetCurrentTransfrom()
        {
            _targetMovement = _transformComponent.GetNextTransform();
            _frogTransform.position = _transformComponent.GetCurrentTransform().position + Vector3.up;
            _nextPosition = _targetMovement.position + Vector3.up;
            _shadowPostionOnGrid = _frogTransform.position;
            _distanceMovement = Vector3.Distance(_shadowPostionOnGrid, _nextPosition);
            _speed = 2.5f;
            Debug.Log(_shadowPostionOnGrid);
            Debug.Log(_nextPosition);
        }

        void OnJump()
        {
            if (_shadowPostionOnGrid == _nextPosition)
            {
                OnEndJump();
                return;
            }
            _shadowPostionOnGrid = Vector3.MoveTowards(_shadowPostionOnGrid, _nextPosition, _speed * Time.fixedDeltaTime);
            _frogTransform.position = _shadowPostionOnGrid + Vector3.up * GetHeight();
        }

        void OnEndJump()
        {
            _transformComponent.SetCurrentTransform(_targetMovement);
            Map.MapControl.Instance.SpawnNext(_transformComponent.GetCurrentTransform());
            ExitState();
        }

        float GetHeight()
        {
            float x = _distanceMovement - Vector3.Distance(_shadowPostionOnGrid, _nextPosition);
            return _trajectoryJump.Evaluate(x);
        }
    }
}
