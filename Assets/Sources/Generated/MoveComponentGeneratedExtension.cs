using Entitas;

namespace Entitas {
    public partial class Entity {
        public MoveComponent move { get { return (MoveComponent)GetComponent(CoreComponentIds.Move); } }

        public bool hasMove { get { return HasComponent(CoreComponentIds.Move); } }

        public Entity AddMove(float newSpeed, float newMaxSpeed) {
            var componentPool = GetComponentPool(CoreComponentIds.Move);
            var component = (MoveComponent)(componentPool.Count > 0 ? componentPool.Pop() : new MoveComponent());
            component.speed = newSpeed;
            component.maxSpeed = newMaxSpeed;
            return AddComponent(CoreComponentIds.Move, component);
        }

        public Entity ReplaceMove(float newSpeed, float newMaxSpeed) {
            var componentPool = GetComponentPool(CoreComponentIds.Move);
            var component = (MoveComponent)(componentPool.Count > 0 ? componentPool.Pop() : new MoveComponent());
            component.speed = newSpeed;
            component.maxSpeed = newMaxSpeed;
            ReplaceComponent(CoreComponentIds.Move, component);
            return this;
        }

        public Entity RemoveMove() {
            return RemoveComponent(CoreComponentIds.Move);;
        }
    }
}

    public partial class CoreMatcher {
        static IMatcher _matcherMove;

        public static IMatcher Move {
            get {
                if (_matcherMove == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Move);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherMove = matcher;
                }

                return _matcherMove;
            }
        }
    }
