
namespace Entity
{
    /* 
     * Cấu hình cho một state:
     * -> EnterState: Xu ly hanh vi khi bat dau mot State
     * -> OnHandler: xu ky hanh dong trong state
     * -> OnFixedUpdate: chay cung luc voi FixedUpdate cua StateComponent
     * -> OnUpdate: Chay cung luc voi Update cua StateComponent
     * -> ExitState: thoa state
     */
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

        public abstract void OnHandler();
        public abstract void UpdateSate();
        public abstract void FixedUpdateState();
        protected abstract void ExitState();
    }
}
