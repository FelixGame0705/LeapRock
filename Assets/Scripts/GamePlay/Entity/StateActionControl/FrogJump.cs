
using System.Collections.Generic;
using UnityEngine;

namespace Entity
{
    internal class FrogJump : StateAction
    {
        IAction _action;
        //List<IAction> _actions = new List<IAction>();
        TransformComponent _transformComponent;
        UnityEngine.AnimationCurve _trajectoryJump;
        public FrogJump(EnityControl enityControl, UnityEngine.AnimationCurve trajectoryJump) : base(enityControl)
        {
            _playAnimation = new PlayAnimationNormal();
            _trajectoryJump = trajectoryJump;
            _transformComponent = enityControl.GetEntityComponent<TransformComponent>();
            _action = new JumpNormal(_transformComponent, _trajectoryJump, ExitState);
            //_actions.Add(new JumpNormal(_transformComponent, _trajectoryJump, ExitState));
            //_actions.Add(new MoveAction(_transformComponent, ExitState));
        }
        public override void EnterState()
        {
            
            base.EnterState();
  
        }

        public override void FixedUpdateState()
        {
            //if(Input.GetKey(KeyCode.Space))
            _action.DoAction();
            //foreach(IAction action in _actions)
            //{
            //    action.DoAction();
            //}
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
