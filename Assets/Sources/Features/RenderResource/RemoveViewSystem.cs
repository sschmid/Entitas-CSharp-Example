using Entitas;
using UnityEngine;

public class RemoveViewSystem : IReactiveSystem, ISetPool {
    public IMatcher trigger { get { return CoreMatcher.Resource; } }

    public GroupEventType eventType { get { return GroupEventType.OnEntityRemoved; } }

    public void SetPool(Pool pool) {
        pool.GetGroup(CoreMatcher.View).OnEntityWillBeRemoved += onEntityWillBeRemoved;
    }

    void onEntityWillBeRemoved(Group group, Entity entity) {
        Object.Destroy(entity.view.gameObject);
    }

    public void Execute(Entity[] entities) {
        foreach (var e in entities) {
            if (e.hasView) {
                e.RemoveView();
            }
        }
    }
}

