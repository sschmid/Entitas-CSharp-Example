using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class AddViewSystem : ReactiveSystem {

    public AddViewSystem(Contexts contexts) : base(contexts.game) {
    }

    protected override Collector GetTrigger(Context context) {
		return context.CreateCollector(GameMatcher.Asset);
    }

    protected override bool Filter(Entity entity) {
		return entity.hasAsset;
    }

    readonly Transform _viewContainer = new GameObject("Views").transform;

    protected override void Execute(List<Entity> entities) {
        foreach(var e in entities) {
			var assetName = Resources.Load<GameObject>(e.asset.name);
            GameObject gameObject = null;
            try {
                gameObject = UnityEngine.Object.Instantiate(assetName);
            } catch(Exception) {
                Debug.Log("Cannot instantiate " + assetName);
            }

            if(gameObject != null) {
                gameObject.transform.parent = _viewContainer;
                e.AddView(gameObject);
            }
        }
    }
}