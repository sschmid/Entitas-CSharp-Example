using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RemoveViewSystem : ISetPool, IMultiReactiveSystem, IEnsureComponents {

    public TriggerOnEvent[] triggers {
        get {
            return new [] {
                CoreMatcher.Resource.OnEntityRemoved(),
                Matcher.AllOf(CoreMatcher.Resource, CoreMatcher.Destroy).OnEntityAdded()
            };
        }
    }

    public IMatcher ensureComponents { get { return CoreMatcher.View; } }

    public void SetPool(Pool pool) {
        pool.GetGroup(CoreMatcher.View).OnEntityRemoved += onEntityRemoved;
    }

    void onEntityRemoved(Group group, Entity entity, int index, IComponent component) {
        var viewComponent = (ViewComponent)component;
        Object.Destroy(viewComponent.gameObject);
    }

    public void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            e.RemoveView();
        }
    }
}
