namespace Entitas {
    public partial class Pool {
        public ISystem CreateCreatePlayerSystem() {
            return this.CreateSystem<CreatePlayerSystem>();
        }
    }
}