namespace Entitas {
    public partial class Entity {
        static readonly DestroyComponent destroyComponent = new DestroyComponent();

        public bool isDestroy {
            get { return HasComponent(ComponentIds.Destroy); }
            set {
                if (value != isDestroy) {
                    if (value) {
                        AddComponent(ComponentIds.Destroy, destroyComponent);
                    } else {
                        RemoveComponent(ComponentIds.Destroy);
                    }
                }
            }
        }
    }

    public static partial class Matcher {
        static AllOfEntityMatcher _matcherDestroy;

        public static AllOfEntityMatcher Destroy {
            get {
                if (_matcherDestroy == null) {
                    _matcherDestroy = Matcher.AllOf(new [] { ComponentIds.Destroy });
                }

                return _matcherDestroy;
            }
        }
    }
}
