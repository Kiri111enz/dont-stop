using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _mover;
    
    private InputActions _input;

    private void SetUpInput()
    {
        _input = new InputActions();

        _input.Game.Move.performed += context => _mover.Direction = (Direction) context.ReadValue<float>();
        _input.Game.Move.canceled += context => _mover.Direction = (Direction) context.ReadValue<float>();
    }

    private void Awake() => SetUpInput();

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();
}
