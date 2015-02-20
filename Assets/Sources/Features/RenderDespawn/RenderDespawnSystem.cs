using Entitas;
using UnityEngine;

public class RenderDespawnSystem : ISystem, ISetPool {

    public void SetPool(Pool pool) {
        pool.GetGroup(Matcher.View).OnEntityWillBeRemoved += onEntityWillBeRemoved;
    }

    void onEntityWillBeRemoved(Group group, Entity entity) {
        Object.Destroy(entity.view.gameObject);
    }
}

