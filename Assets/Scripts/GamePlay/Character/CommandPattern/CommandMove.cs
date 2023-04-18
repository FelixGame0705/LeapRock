using Entity;
using UnityEngine;

namespace CommandPattern
{
    internal class CommandMoveLeft : Command
    {
        [SerializeField] float maxDistanceMove = 2.5f;
        private TransformComponent _transformComponent;
        private Transform _transform;
        private Vector3 _none;
        private Vector3 _nextPosition;
        private Vector2Int _mapSize;

        public CommandMoveLeft(TransformComponent transformComponent, Vector2Int mapSize)
        {
            _transformComponent = transformComponent;
            _transform = _transformComponent._transform;
            _mapSize = mapSize;
        }
        public override void Execute()
        {
            DoAction();
        }

        public void DoAction()
        {
            if (_transformComponent.GetNextTransformColumnLeft().x <= -1) return;
            SetValueMoveLeft();
            _none = Vector3.MoveTowards(_none, _nextPosition, maxDistanceMove * Time.deltaTime);
        }

        private void SetValueMoveLeft()
        {
            _none = _transform.position;
            _nextPosition = _transformComponent.GetNextTransformColumnLeft().position + Vector3.up;
            OnEndMove();

        }

        private void OnEndMove()
        {
            _transformComponent.SetCurrentTransform(_transformComponent.GetNextTransformColumnLeft());
            Debug.Log("Finish sorting");
        }

    }

    internal class CommandMoveRight : Command
    {
        private TransformComponent _transformComponent;
        private Transform _transform;
        private Vector3 _none;
        private Vector3 _nextPosition;
        private Vector2Int _mapSize;

        public CommandMoveRight(TransformComponent transformComponent, Vector2Int mapSize)
        {
            _transformComponent = transformComponent;
            _transform = _transformComponent._transform;
            _mapSize = mapSize;
        }
        public override void Execute()
        {
            DoAction();
        }

        public void DoAction()
        {
            if(_transformComponent.GetNextTransformColumnRight().x >= _mapSize.x) return;
            SetValueMoveRight();
            
            UnityEngine.Debug.Log("Get action Jump " + _transformComponent._transform.position.x);
            _none = Vector3.MoveTowards(_none, _nextPosition, 2.5f * Time.deltaTime);
        }

        private void SetValueMoveRight()
        {
            _none = _transform.position;
            _nextPosition = _transformComponent.GetNextTransformColumnRight().position + Vector3.up;
            OnEndMove();
        }

        private void OnEndMove()
        {
            _transformComponent.SetCurrentTransform(_transformComponent.GetNextTransformColumnRight());
        }
    }

    //Remove previous feature command
}
