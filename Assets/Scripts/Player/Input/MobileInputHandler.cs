using System;

public class MobileInputHandler : IInput
{
    private Joystick _joystick;

    public MobileInputHandler(Joystick joystick)
    {
        if (joystick == null)
            throw new ArgumentNullException(nameof(joystick));
    
        _joystick = joystick;
    }

    public float GetHorizontalMovementInput()
    {
        float horizontalMovementInput = _joystick.Horizontal;

        return horizontalMovementInput;
    }

    public float GetVerticalMovementInput()
    {
        float verticalMovementInput = _joystick.Vertical;

        return verticalMovementInput;
    }
}
