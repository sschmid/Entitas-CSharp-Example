using Entitas;
using UnityEngine;

public sealed class InputSystem : ISetPool, IExecuteSystem {

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute() {
        _pool.isAccelerating = Input.GetMouseButton(0);
    }
}
