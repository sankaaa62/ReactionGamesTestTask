using CodeBase.Actors.Moving;
using UnityEngine;

namespace CodeBase.Input
{
    public class PlayerInput : MonoBehaviour
    {
        private IMover _mover;
        private PlayerInputActions _inputActions;
        private Vector3 _moveDirection;
        private Camera _camera;

        private void Construct()
        {
            _mover = GetComponent<IMover>();
            if (_mover == null) 
                Debug.LogError("The component implementing the interface <IMover> was not found.");
            
            _inputActions = new PlayerInputActions();
        }

        private void Awake()
        {
            Construct();
            
            _inputActions.Player.Enable();
            _camera = Camera.main;
        }

        private void Update()
        {
            _moveDirection = _camera.transform.TransformDirection(_inputActions.Player.Move.ReadValue<Vector2>());
            _moveDirection.y = 0f;
            _moveDirection.Normalize();
            
            _mover.Move(_moveDirection);
        }
    }
}
