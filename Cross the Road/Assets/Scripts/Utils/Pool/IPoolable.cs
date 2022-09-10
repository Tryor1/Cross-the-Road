using UnityEngine;

namespace Utils
{
    public interface IPoolable
    {
        void PrepareForActivate();
        void PrepareForDeactivate(Transform parent);
    }
}
