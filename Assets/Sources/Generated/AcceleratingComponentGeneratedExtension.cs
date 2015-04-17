using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly AcceleratingComponent acceleratingComponent = new AcceleratingComponent();

        public bool isAccelerating {
            get { return HasComponent(CoreComponentIds.Accelerating); }
            set {
                if (value != isAccelerating) {
                    if (value) {
                        AddComponent(CoreComponentIds.Accelerating, acceleratingComponent);
                    } else {
                        RemoveComponent(CoreComponentIds.Accelerating);
                    }
                }
            }
        }
    }

    public partial class Pool {
        public Entity acceleratingEntity { get { return GetGroup(CoreMatcher.Accelerating).GetSingleEntity(); } }

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
}

    public partial class CoreMatcher {
        static AllOfMatcher _matcherAccelerating;

        public static AllOfMatcher Accelerating {
            get {
                if (_matcherAccelerating == null) {
                    _matcherAccelerating = new CoreMatcher(CoreComponentIds.Accelerating);
                }

                return _matcherAccelerating;
            }
        }
    }
