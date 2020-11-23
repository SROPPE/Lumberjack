
using UnityEngine;
namespace Lumberjack.HealthSystem
{
    public interface IDamagable
    {
        void TakeDamage(GameObject from, float damage);
    }
}

