using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public ViewComponent view { get { return (ViewComponent)GetComponent(CoreComponentIds.View); } }

        public bool hasView { get { return HasComponent(CoreComponentIds.View); } }

        static readonly Stack<ViewComponent> _viewComponentPool = new Stack<ViewComponent>();

        public static void ClearViewComponentPool() {
            _viewComponentPool.Clear();
        }

        public Entity AddView(UnityEngine.GameObject newGameObject) {
            var component = _viewComponentPool.Count > 0 ? _viewComponentPool.Pop() : new ViewComponent();
            component.gameObject = newGameObject;
            return AddComponent(CoreComponentIds.View, component);
        }

        public Entity ReplaceView(UnityEngine.GameObject newGameObject) {
            var previousComponent = hasView ? view : null;
            var component = _viewComponentPool.Count > 0 ? _viewComponentPool.Pop() : new ViewComponent();
            component.gameObject = newGameObject;
            ReplaceComponent(CoreComponentIds.View, component);
            if (previousComponent != null) {
                _viewComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveView() {
            var component = view;
            RemoveComponent(CoreComponentIds.View);
            _viewComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreMatcher {
        static IMatcher _matcherView;

        public static IMatcher View {
            get {
                if (_matcherView == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.View);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherView = matcher;
                }

                return _matcherView;
            }
        }
    }
