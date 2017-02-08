using Entitas;
using UnityEngine;

public sealed class InputSystem : IExecuteSystem {

    readonly Context _context;

    public InputSystem(Contexts contexts) {
        _context = contexts.input;
    }

    public void Execute() {
        _context.isAccelerating =
            Input.GetButton("Fire1") ||
            Input.GetAxisRaw("Vertical") > 0;
    }
}
