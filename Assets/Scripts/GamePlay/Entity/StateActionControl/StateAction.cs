
namespace Entity
{
    internal abstract class StateAction
    {
        protected StateActionComponent _stateActionComponent;
        protected AnimatorComponent _animatorComponent;
        protected IPlayAnimation _playAnimation;
        public StateAction(EnityControl enityControl)
        {
            _stateActionComponent = enityControl.GetEntityComponent<StateActionComponent>();
            _animatorComponent = enityControl.GetEntityComponent<AnimatorComponent>();
        }
        public virtual void EnterState()
        {
            _animatorComponent.PlayAnimator(_playAnimation);
        }
        public abstract void UpdateSate();
        public abstract void FixedUpdateState();
        protected abstract void ExitState();
    }
}
