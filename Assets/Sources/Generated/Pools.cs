using Entitas;

public static class Pools {

    static Pool _core;

    public static Pool core {
        get {
            if (_core == null) {
                #if (UNITY_EDITOR)
                var pool = new Entitas.Unity.VisualDebugging.DebugPool(CoreComponentIds.TotalComponents, "Core Pool");
                UnityEngine.Object.DontDestroyOnLoad(pool.entitiesContainer);
                _core = pool;
                #else
                _core = new Pool(CoreComponentIds.TotalComponents);
                #endif
            }

            return _core;
        }
    }
}