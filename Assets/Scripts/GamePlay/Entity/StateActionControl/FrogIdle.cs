using UnityEngine;
namespace Entity
{
    internal class FrogIdle : StateAction
    {
        IAction _action;
        float _time;
        public FrogIdle(EnityControl enityControl) : base(enityControl)
        {
            _playAnimation = new PlayAnimationNormal();
            _action = new IdleNormal();
        }
        public override void EnterState()
        {
            _time = 0.2f;
            base.EnterState();
            _action.DoAction();
        }
        public override void FixedUpdateState()
        {

        }

        public override void UpdateSate()
        {
            _time -= Time.deltaTime;
            if (_time <=0f)
            {
                _stateActionComponent.SwitchState(_stateActionComponent.GetSateAction("Jump"));
            }
        }

        protected override void ExitState()
        {
            
        }
    }
}
