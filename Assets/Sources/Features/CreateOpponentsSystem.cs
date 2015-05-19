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
            var speed = Random.value * 0.02f;
            _pool.CreateEntity()
                .AddResource(resourceName)
                .AddPosition(i, 0, 0)
                .AddMove(speed, speed);
        }
    }
}

