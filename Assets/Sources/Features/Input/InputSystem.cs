using Entitas;
using UnityEngine;

[Core]
public class InputSystem : IExecuteSystem, ISetPool {
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute() {
        _pool.isAccelerating = Input.GetMouseButton(0);
    }
}

