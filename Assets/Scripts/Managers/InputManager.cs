using Lab.Input;
using System;

namespace Lab.Managers
{
    public class InputManager : IDisposable
    {
        private InputActions _inputActions;

        public InputActions InputActions => _inputActions;

        public InputManager()
        {
            _inputActions = new();
            _inputActions.Enable();
        }

        public void Dispose() => _inputActions.Dispose();
    }
}