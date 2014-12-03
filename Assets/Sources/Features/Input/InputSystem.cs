using Entitas;
using UnityEngine;

public class InputSystem : IEntitySystem, ISetEntityRepository {
    EntityRepository _repo;

    public void SetEntityRepository(EntityRepository repo) {
        _repo = repo;
    }

    public void Execute() {
        _repo.isAccelerate = Input.GetMouseButton(0);
    }
}

