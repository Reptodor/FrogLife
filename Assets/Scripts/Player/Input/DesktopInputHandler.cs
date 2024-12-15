using UnityEngine;

public class DesktopInputHandler : IInput
{
    public float GetHorizontalMovementInput()
    {
        float horizontalMovementInput = Input.GetAxisRaw("Horizontal");

        return horizontalMovementInput;
    }

    public float GetVerticalMovementInput()
    {
        float verticalMovementInput = Input.GetAxisRaw("Vertical");

        return verticalMovementInput;
    }
}
