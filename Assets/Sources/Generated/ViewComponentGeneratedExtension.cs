using Entitas;

namespace Entitas {
    public partial class Entity {
        public ViewComponent view { get { return (ViewComponent)GetComponent(CoreComponentIds.View); } }

        public bool hasView { get { return HasComponent(CoreComponentIds.View); } }

        public void AddView(ViewComponent component) {
            AddComponent(CoreComponentIds.View, component);
        }

        public void AddView(UnityEngine.GameObject newGameObject) {
            var component = new ViewComponent();
            component.gameObject = newGameObject;
            AddView(component);
        }

        public void ReplaceView(UnityEngine.GameObject newGameObject) {
            ViewComponent component;
            if (hasView) {
                WillRemoveComponent(CoreComponentIds.View);
                component = view;
            } else {
                component = new ViewComponent();
            }
            component.gameObject = newGameObject;
            ReplaceComponent(CoreComponentIds.View, component);
        }

        public void RemoveView() {
            RemoveComponent(CoreComponentIds.View);
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
