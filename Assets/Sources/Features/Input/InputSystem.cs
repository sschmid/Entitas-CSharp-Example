using Entitas;
using UnityEngine;

public sealed class InputSystem : ISetPool, IExecuteSystem {

    Context _pool;

    public void SetPool(Context pool) {
        _pool = pool;
    }

    public void Execute() {
        _pool.isAccelerating =
            Input.GetButton("Fire1") ||
            Input.GetAxisRaw("Vertical") > 0;
    }
}
