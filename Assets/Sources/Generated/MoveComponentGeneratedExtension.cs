using System.Collections.Generic;

using Entitas;

namespace Entitas {
    public partial class Entity {
        public MoveComponent move { get { return (MoveComponent)GetComponent(CoreComponentIds.Move); } }

        public bool hasMove { get { return HasComponent(CoreComponentIds.Move); } }

        static readonly Stack<MoveComponent> _moveComponentPool = new Stack<MoveComponent>();

        public static void ClearMoveComponentPool() {
            _moveComponentPool.Clear();
        }

        public Entity AddMove(float newSpeed, float newMaxSpeed) {
            var component = _moveComponentPool.Count > 0 ? _moveComponentPool.Pop() : new MoveComponent();
            component.speed = newSpeed;
            component.maxSpeed = newMaxSpeed;
            return AddComponent(CoreComponentIds.Move, component);
        }

        public Entity ReplaceMove(float newSpeed, float newMaxSpeed) {
            var previousComponent = move;
            var component = _moveComponentPool.Count > 0 ? _moveComponentPool.Pop() : new MoveComponent();
            component.speed = newSpeed;
            component.maxSpeed = newMaxSpeed;
            ReplaceComponent(CoreComponentIds.Move, component);
            if (previousComponent != null) {
                _moveComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveMove() {
            var component = move;
            RemoveComponent(CoreComponentIds.Move);
            _moveComponentPool.Push(component);
            return this;
        }
    }
}

    public partial class CoreMatcher {
        static AllOfMatcher _matcherMove;

        public static AllOfMatcher Move {
            get {
                if (_matcherMove == null) {
                    _matcherMove = new CoreMatcher(CoreComponentIds.Move);
                }

                return _matcherMove;
            }
        }
    }
