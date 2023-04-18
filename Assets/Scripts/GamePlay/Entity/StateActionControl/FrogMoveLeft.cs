using System.Collections.Generic;
using UnityEngine;
using Map;
namespace Entity
{
    /*
     * Lam con ech nhay qua trai
     */
    internal class FrogMoveLeft : StateAction
    {
        TransformComponent _transformComponent;
        Transform _frogTransform;
        EnvironmentTransform _targetMovement;
        Vector3 _shadowOnGrid;
        Vector3 _nextPosition;

        float _speed;

        float _height;
        float _distanceMovement;

        public FrogMoveLeft(EnityControl enityControl) : base(enityControl)
        {
            _playAnimation = new PlayAnimationNormal();
            _transformComponent = enityControl.GetEntityComponent<TransformComponent>();
            _frogTransform = _transformComponent._transform;
        }
        public override void EnterState()
        {
            base.EnterState();
            SetCurrentTransform();
        }

        public override void FixedUpdateState()
        {
        }

        public override void OnHandler()
        {
            OnMove();
        }

        public override void UpdateSate()
        {
            OnHandler();
        }

        protected override void ExitState()
        {
            _stateActionComponent.SwitchState(_stateActionComponent.GetSateAction("Jump"));
        }

        void SetCurrentTransform()
        {
            _targetMovement = MaterialEnvironmentControl.Intanse.GetNextEnvironmentTransformColLeft(MaterialEnvironmentControl.Intanse.GetNextEnvironmentTransformRow(_transformComponent._currentTransform));
            _shadowOnGrid = new Vector3(_frogTransform.position.x, 0f, _frogTransform.position.z) + Vector3.up;
            _nextPosition = _targetMovement.position + Vector3.up;
            _speed = 2.5f;
            _height = _frogTransform.position.y;
            _distanceMovement = Vector3.Distance(_shadowOnGrid, _nextPosition);
        }

        public void OnMove()
        {
            if (_shadowOnGrid == _nextPosition)
            {
                OnEndMove();
                return;
            }
            _shadowOnGrid = Vector3.MoveTowards(_shadowOnGrid, _nextPosition, _speed * Time.deltaTime);
            _frogTransform.position = new Vector3(_shadowOnGrid.x, GetHeighMove(), _shadowOnGrid.z) + Vector3.up;
        }

        float GetHeighMove()
        {
            float x = _distanceMovement - Vector3.Distance(_shadowOnGrid, _nextPosition);
            return (-_height * x * x) / (_distanceMovement * _distanceMovement) + _height;
        }

        void OnEndMove()
        {
            _transformComponent.SetCurrentTransform(_targetMovement);
            Map.MapControl.Instance.SpawnNext(_transformComponent._currentTransform);
            ExitState();
        }
    }
}
