namespace Entitas {
    public partial class Entity {
        static readonly AcceleratingComponent acceleratingComponent = new AcceleratingComponent();

        public bool isAccelerating {
            get { return HasComponent(ComponentIds.Accelerating); }
            set {
                if (value != isAccelerating) {
                    if (value) {
                        AddComponent(ComponentIds.Accelerating, acceleratingComponent);
                    } else {
                        RemoveComponent(ComponentIds.Accelerating);
                    }
                }
            }
        }
    }

    public partial class Pool {
        public Entity acceleratingEntity { get { return GetGroup(Matcher.Accelerating).GetSingleEntity(); } }

        public bool isAccelerating {
            get { return acceleratingEntity != null; }
            set {
                var entity = acceleratingEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isAccelerating = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }

    public static partial class Matcher {
        static AllOfMatcher _matcherAccelerating;

        public static AllOfMatcher Accelerating {
            get {
                if (_matcherAccelerating == null) {
                    _matcherAccelerating = Matcher.AllOf(new [] { ComponentIds.Accelerating });
                }

                return _matcherAccelerating;
            }
        }
    }
}