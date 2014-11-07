using Entitas;
using UnityEngine;

public class RenderDespawnSystem : IReactiveSubEntityWillBeRemovedSystem {
    public int GetTriggeringIndex() {
        return ComponentIds.View;
    }

    public void Execute(EntityComponentPair[] pairs) {
        foreach (var pair in pairs) {
            var view = (ViewComponent)pair.component;
            Object.Destroy(view.gameObject);
        }
    }
}

