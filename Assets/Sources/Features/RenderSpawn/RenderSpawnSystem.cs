using Entitas;
using UnityEngine;

public class RenderSpawnSystem : IReactiveSubEntitySystem {
    public IEntityMatcher GetTriggeringMatcher() {
        return Matcher.Resource;
    }

    public EntityCollectionEventType GetEventType() {
        return EntityCollectionEventType.OnEntityAdded;
    }

    readonly Transform _viewContainer = new GameObject("Views").transform;

    public void Execute(Entity[] entities) {
        foreach (var e in entities) {
            var res = Resources.Load<GameObject>(e.resource.name);
            var gameObject = (GameObject)Object.Instantiate(res);
            gameObject.transform.parent = _viewContainer;
            e.AddView(gameObject);
        }
    }
}
