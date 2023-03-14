using UnityEngine;

namespace PlayerInput
{
    internal class PlayerTouchAction : MonoBehaviour
    {
        private IInputFactory _inputFactory;
        private IInputAction _inputAction;
        private void Awake()
        {
            _inputFactory = new PlayerInputFactory();
            _inputAction = null;

        }
        private void Update()
        {
            CheckInput();
        }
        private void CheckInput()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _inputAction = _inputFactory.GetInputAction(TypeInput.Rock);
                _inputAction?.Action();
            }
        }
    }
}
