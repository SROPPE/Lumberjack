using System;
using UnityEngine;
namespace Lumberjack.HealthSystem
{
    public class TakeDamageEventArgs : EventArgs
    {
        public GameObject From { get; set; }
        public float Amount { get; set; }
        public float PercentageDamage { get; set; }

    }
    public class Health : MonoBehaviour, IDamagable
    {
        [SerializeField] Destruction destructionSequence;
        [SerializeField] private float maxHealthPoints = 1;

        private float _currentHealthPoints;
        private TakeDamageEventArgs _eventArgs;

        public event EventHandler<TakeDamageEventArgs> DamageReceived;
        public event EventHandler<TakeDamageEventArgs> Death;

        private void Awake()
        {
            _eventArgs = new TakeDamageEventArgs();
            _currentHealthPoints = maxHealthPoints;
        }
        public void SetHealth(float value)
        {
            maxHealthPoints = value;
            _currentHealthPoints = value;
        }
        public void TakeDamage(GameObject from, float damage)
        {
            if (_currentHealthPoints > 0)
            {
                _currentHealthPoints -= damage;
                SetEventArgs(from, damage, damage / maxHealthPoints);
                DamageReceived?.Invoke(this, _eventArgs);
            }
            if (_currentHealthPoints <= 0)
            {
                Death?.Invoke(this, _eventArgs);
                Destroy(gameObject);

            }
            if (destructionSequence != null)
            {
                StartCoroutine(destructionSequence.DestructionSequenceCorutine(this));
            }
        }
        private void SetEventArgs(GameObject from, float amount, float amountNormalized)
        {
            _eventArgs.From = from;
            _eventArgs.Amount = amount;
            _eventArgs.PercentageDamage = Mathf.Clamp(amountNormalized, 0f, 1f);
        }
    }
}