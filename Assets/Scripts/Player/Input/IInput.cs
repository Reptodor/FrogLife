using UnityEngine;

public interface IInput 
{
    Vector2 MovementDirenction => new Vector2(GetHorizontalMovementInput(), GetVerticalMovementInput());

    float GetHorizontalMovementInput();

    float GetVerticalMovementInput();
}
