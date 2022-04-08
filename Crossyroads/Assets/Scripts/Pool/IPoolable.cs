using UnityEngine;
namespace CarPools
{
    public interface IPoolable
    {
        void PrepareForActivate();
        void PrepareForDeactivate(Transform parent);
    }
}