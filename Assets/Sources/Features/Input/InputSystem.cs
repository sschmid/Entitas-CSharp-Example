using Entitas;
using UnityEngine;

public class InputSystem : IExecuteSystem, ISetPool {
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute() {
        _pool.isAccelerate = Input.GetMouseButton(0);
    }
}

