using Lumberjack.Control;
using UnityEngine;
using UnityEngine.Events;

namespace Lumberjack.Pickup.Config
{
    [CreateAssetMenu(fileName = "Pickup", menuName = "Pickup/Create New Weapon", order = 0)]
    public class PickupWeaponConfig : PickupObjectConfig
    {
        const string weaponName = "Weapon";
        [SerializeField] float _meleeAttackRange;
        [SerializeField] float _timeBetweenAttack = 1f;
        [SerializeField] float _damage = 5f;
        [SerializeField] AnimatorOverrideController _animatorOverride;
        public float MeleeAttackRange => _meleeAttackRange;
        public float TimeBetweenAttack => _timeBetweenAttack;
        public float Damage => _damage;

        public override void ApplyPickup(GameObject player)
        {
            SpawnWeapon(player.GetComponent<Player>().RightArm);
        }
        public void SpawnWeapon(Transform rightHand)
        {
            DestroyOldWeapon(rightHand);
            var currentWeapon = Instantiate(_pickupPrefab,rightHand);
            currentWeapon.name = weaponName;
        }      

        private static void DestroyOldWeapon(Transform rightHand)
        {
            Transform oldWeapon = rightHand.Find(weaponName);
            if (oldWeapon != null)
            {
                oldWeapon.name = "Destoying";
                Destroy(oldWeapon.gameObject);
            }
        }
    }
}
