namespace Entitas {
    public partial class Pool {
        public ISystem CreateReachedFinishSystem() {
            return this.CreateSystem<ReachedFinishSystem>();
        }
    }
}