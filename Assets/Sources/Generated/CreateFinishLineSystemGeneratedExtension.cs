namespace Entitas {
    public partial class Pool {
        public ISystem CreateCreateFinishLineSystem() {
            return this.CreateSystem<CreateFinishLineSystem>();
        }
    }
}