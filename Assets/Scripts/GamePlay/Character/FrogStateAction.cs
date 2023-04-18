using UnityEngine;
using Entity;
namespace Character
{
    internal class FrogStateAction : StateActionComponent
    {
        [SerializeField] AnimationCurve _trajectoryJump;
        public override void InitComponent(EnityControl enityControl)
        {
            _stateActions.Add("Idle", new FrogIdle(enityControl));
            _stateActions.Add("Jump", new FrogJump(enityControl, _trajectoryJump));
            _stateActions.Add("MoveRight", new FrogMoveRight(enityControl));
            _stateActions.Add("MoveLeft", new FrogMoveLeft(enityControl));
        }

        private void Start()
        {
            SwitchState(GetSateAction("Jump"));
        }

        private void Update()
        {
            _currentStateAction.UpdateSate();
        }

        private void FixedUpdate()
        {
            _currentStateAction.FixedUpdateState();
        }
    }
}
