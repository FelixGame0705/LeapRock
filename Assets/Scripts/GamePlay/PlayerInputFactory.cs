namespace PlayerInput
{
    internal class PlayerInputFactory : IInputFactory
    {
        public IInputAction GetInputAction(TypeInput input)
        {
            switch (input)
            {
                case TypeInput.Rock:
                    return new TouchRock();
                default: return null;

            }
        }
    }
}
