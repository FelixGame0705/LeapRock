namespace PlayerInput
{
    internal interface IInputFactory
    {
        IInputAction GetInputAction(TypeInput input);
    }
}
