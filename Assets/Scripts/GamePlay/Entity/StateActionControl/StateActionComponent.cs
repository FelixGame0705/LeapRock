using System.Collections.Generic;
namespace Entity
{
    internal abstract class StateActionComponent : EntityComponent
    {
        protected StateAction _currentStateAction;
        protected Dictionary<string, StateAction> _stateActions = new Dictionary<string, StateAction>();
        public virtual void SwitchState(StateAction stateAction)
        {
            _currentStateAction = stateAction;
            _currentStateAction.EnterState();
        }

        public virtual StateAction GetSateAction(string nameStateAction)
        {
            return _stateActions[nameStateAction];
        }
    }
}
