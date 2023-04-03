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
        }

        private void Start()
        {
            SwitchState(GetSateAction("Idle"));
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
