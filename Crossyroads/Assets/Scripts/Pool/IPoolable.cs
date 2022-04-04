using UnityEngine;
namespace Utilities
{
    public interface IPoolable
    {
        void PrepareForActivate();
        void PrepareForDeactivate(Transform parent);
    }
}