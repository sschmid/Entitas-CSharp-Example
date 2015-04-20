using Entitas;
using UnityEngine;

public class CreateOpponentsSystem : IStartSystem, ISetPool {
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Start() {
        const string resourceName = "Opponent";
        for (int i = 1; i < 10; i++) {
            var e = _pool.CreateEntity();
            e.AddResource(resourceName);
            e.AddPosition(i, 0, 0);
            var speed = Random.value * 0.02f;
            e.AddMove(speed, speed);
        }
    }
}

