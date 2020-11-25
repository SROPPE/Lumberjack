using Lumberjack.HealthSystem;
using Lumberjack.Stats;
using System.Collections.Generic;
using UnityEngine;

namespace Lumberjack.Actions.Combat
{
    [RequireComponent(typeof(ActionScheduler))]
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] GameObjectsContainer enemiesInFOV;
        [SerializeField] GameObjectsContainer enemiesInAttackRadius;
        [SerializeField] BaseStats baseStats;
      

        private Animator _animator;
        private ActionScheduler _actionScheduler;
        private List<GameObject> _enemiesInFOV;

        private float _timeScinceLastAttack = Mathf.Infinity;

        private void Awake()
        {
            _enemiesInFOV = new List<GameObject>();
            _actionScheduler = GetComponent<ActionScheduler>();
            _animator = GetComponent<Animator>();
        }
        private void Update()
        {
            _timeScinceLastAttack += Time.deltaTime;
        }
        public bool StartFight()
        {
            _enemiesInFOV = enemiesInFOV.Items;

            if (_enemiesInFOV.Count == 0)
            {
                Cancel();
                return false;
            }
            if (_timeScinceLastAttack > baseStats.GetStat(Stat.AttackSpeed))
            {
                _timeScinceLastAttack = 0f;

                _actionScheduler.StartAction(this);
                var position = FindClosestEnemyPosition();
                RotateToClosestEnemy(position);
                UpdateAnimator();
                return true;
            }
            return false;
        }

        private Vector3 FindClosestEnemyPosition()
        {
            float minDistance = Mathf.Infinity;
            int closestEnemyIndex = 0;
            Vector3 result = transform.forward;
            
            for (int i = 0; i < _enemiesInFOV.Count; i++)
            {
                if (_enemiesInFOV[i] == null) continue;
                float distanceToEnemy = Vector3.Distance(transform.position, _enemiesInFOV[i].transform.position);
                if (distanceToEnemy < minDistance)
                { 
                    minDistance = distanceToEnemy;
                    closestEnemyIndex = i;
                }
                result = _enemiesInFOV[closestEnemyIndex].transform.position;
            }
            return result;
        }
        private void RotateToClosestEnemy(Vector3 enemy)
        {
            var enemyPosition = new Vector3(enemy.x,transform.position.y,enemy.z);
            transform.LookAt(enemyPosition);
        }
        public void Hit()
        {
            float damage = baseStats.GetStat(Stat.Damage);
            var enemiesInAttackRange = enemiesInAttackRadius.Items;
            foreach (var enemy in enemiesInAttackRange)
            {
                if (enemy)
                {
                    var damageableParts = enemy.GetComponents<IDamagable>();
                    foreach (var part in damageableParts)
                    {
                        part.TakeDamage(gameObject, damage);
                    }
                }
            }
        }
        private void UpdateAnimator()
        {
            _animator.ResetTrigger("StopAttack");
            _animator.SetTrigger("Attack");
        }
        public void Cancel()
        {
            _animator.ResetTrigger("Attack");
            _animator.SetTrigger("StopAttack");
        }
    } 
}
