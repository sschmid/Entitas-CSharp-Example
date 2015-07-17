using Entitas;

namespace Entitas {
    public partial class Entity {
        public ViewComponent view { get { return (ViewComponent)GetComponent(CoreComponentIds.View); } }

        public bool hasView { get { return HasComponent(CoreComponentIds.View); } }

        public Entity AddView(ViewComponent component) {
            return AddComponent(CoreComponentIds.View, component);
        }

        public Entity AddView(UnityEngine.GameObject newGameObject) {
            var component = new ViewComponent();
            component.gameObject = newGameObject;
            return AddView(component);
        }

        public Entity ReplaceView(UnityEngine.GameObject newGameObject) {
            ViewComponent component;
            if (hasView) {
                WillRemoveComponent(CoreComponentIds.View);
                component = view;
            } else {
                component = new ViewComponent();
            }
            component.gameObject = newGameObject;
            return ReplaceComponent(CoreComponentIds.View, component);
        }

        public Entity RemoveView() {
            return RemoveComponent(CoreComponentIds.View);
        }
    }
}

    public partial class CoreMatcher {
        static AllOfMatcher _matcherView;

        public static AllOfMatcher View {
            get {
                if (_matcherView == null) {
                    _matcherView = new CoreMatcher(CoreComponentIds.View);
                }

                return _matcherView;
            }
        }
    }
