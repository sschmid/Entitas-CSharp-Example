namespace Entitas {
    public partial class Entity {
        static readonly AccelerateComponent accelerateComponent = new AccelerateComponent();

        public bool isAccelerate {
            get { return HasComponent(ComponentIds.Accelerate); }
            set {
                if (value != isAccelerate) {
                    if (value) {
                        AddComponent(ComponentIds.Accelerate, accelerateComponent);
                    } else {
                        RemoveComponent(ComponentIds.Accelerate);
                    }
                }
            }
        }
    }

    public partial class Pool {
        public Entity accelerateEntity { get { return GetGroup(Matcher.Accelerate).GetSingleEntity(); } }

        public bool isAccelerate {
            get { return accelerateEntity != null; }
            set {
                var entity = accelerateEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isAccelerate = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }

    public static partial class Matcher {
        static AllOfMatcher _matcherAccelerate;

        public static AllOfMatcher Accelerate {
            get {
                if (_matcherAccelerate == null) {
                    _matcherAccelerate = Matcher.AllOf(new [] { ComponentIds.Accelerate });
                }

                return _matcherAccelerate;
            }
        }
    }
}