using Entitas;
using UnityEngine;

public class RemoveViewSystem : IMultiReactiveSystem, ISetPool, IEnsureComponents {
    public IMatcher[] triggers { get { return new [] {
            CoreMatcher.Resource,
            Matcher.AllOf(CoreMatcher.Resource, CoreMatcher.Destroy)
        }; } }

    public GroupEventType[] eventTypes { get { return new [] {
            GroupEventType.OnEntityRemoved,
            GroupEventType.OnEntityAdded
        }; } }

    public IMatcher ensureComponents { get { return CoreMatcher.View; } }

    public void SetPool(Pool pool) {
        pool.GetGroup(CoreMatcher.View).OnEntityRemoved += onEntityRemoved;
    }

    void onEntityRemoved(Group group, Entity entity, int index, IComponent component) {
        var viewComponent = (ViewComponent)component;
        Object.Destroy(viewComponent.gameObject);
    }

    public void Execute(System.Collections.Generic.List<Entity> entities) {
        foreach (var e in entities) {
            e.RemoveView();
        }
    }
}

