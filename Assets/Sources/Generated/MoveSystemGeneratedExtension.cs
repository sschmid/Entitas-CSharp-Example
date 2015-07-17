namespace Entitas {
    public partial class Pool {
        public ISystem CreateMoveSystem() {
            return this.CreateSystem<MoveSystem>();
        }
    }
}