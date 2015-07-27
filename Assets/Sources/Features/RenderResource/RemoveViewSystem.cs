using Entitas;
using UnityEngine;

public class RemoveViewSystem : IReactiveSystem, ISetPool {
    public IMatcher trigger { get { return CoreMatcher.Resource; } }

    public GroupEventType eventType { get { return GroupEventType.OnEntityRemoved; } }

    public void SetPool(Pool pool) {
        pool.GetGroup(CoreMatcher.View).OnEntityRemoved += onEntityRemoved;
    }

    void onEntityRemoved(Group group, Entity entity, int index, IComponent component) {
        var viewComponent = (ViewComponent)component;
        Object.Destroy(viewComponent.gameObject);
    }

    public void Execute(System.Collections.Generic.List<Entity> entities) {
        foreach (var e in entities) {
            if (e.hasView) {
                e.RemoveView();
            }
        }
    }
}

