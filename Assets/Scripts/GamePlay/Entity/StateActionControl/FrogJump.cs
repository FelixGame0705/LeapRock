
namespace Entity
{
    internal class FrogJump : StateAction
    {
        IAction _action;
        TransformComponent _transformComponent;
        UnityEngine.AnimationCurve _trajectoryJump;
        public FrogJump(EnityControl enityControl, UnityEngine.AnimationCurve trajectoryJump) : base(enityControl)
        {
            _playAnimation = new PlayAnimationNormal();
            _trajectoryJump = trajectoryJump;
            _transformComponent = enityControl.GetEntityComponent<TransformComponent>();
            _action = new JumpNormal(_transformComponent, _trajectoryJump, ExitState);

        }
        public override void EnterState()
        {
            
            base.EnterState();
  
        }

        public override void FixedUpdateState()
        {
            _action.DoAction();
        }

        public override void UpdateSate()
        {
            
        }

        protected override void ExitState()
        {
            _stateActionComponent.SwitchState(_stateActionComponent.GetSateAction("Idle"));
        }
    }
}
