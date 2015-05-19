using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly DestroyComponent destroyComponent = new DestroyComponent();

        public bool isDestroy {
            get { return HasComponent(CoreComponentIds.Destroy); }
            set {
                if (value != isDestroy) {
                    if (value) {
                        AddComponent(CoreComponentIds.Destroy, destroyComponent);
                    } else {
                        RemoveComponent(CoreComponentIds.Destroy);
                    }
                }
            }
        }

        public Entity IsDestroy(bool value) {
            isDestroy = value;
            return this;
        }
    }
}

    public partial class CoreMatcher {
        static AllOfMatcher _matcherDestroy;

        public static AllOfMatcher Destroy {
            get {
                if (_matcherDestroy == null) {
                    _matcherDestroy = new CoreMatcher(CoreComponentIds.Destroy);
                }

                return _matcherDestroy;
            }
        }
    }
