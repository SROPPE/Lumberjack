using Lumberjack.Actions.Movement;
using Lumberjack.Actions.Combat;
using UnityEngine;
using Lumberjack.Stats;

namespace Lumberjack.Control
{
    [RequireComponent(typeof(BasicMovement), typeof(Fighter))]
    public class Player : MonoBehaviour, IStatsProvider
    {
        [SerializeField] private Joystick movementJoystick;
        [SerializeField] private Transform rightArm;
        [SerializeField] private Transform basePoint;
        [SerializeField] private BaseStats playerStats;

        private Fighter _fighter;
        private BasicMovement _movement;

        private Vector3 _movementDirection;

        public Transform RightArm => rightArm;
        public BaseStats stats => playerStats;

        public void TeleportToBasePoint()
        {
            if (basePoint != null)
            {
                _movement.Cancel();
                _fighter.Cancel();
                transform.position = basePoint.position;
            }
        }
        void Awake()
        {
            _movement = GetComponent<BasicMovement>();
            _fighter = GetComponent<Fighter>();

        }
        private void Update()
        {
            UpdatePlayerInput();
        }

        private void UpdatePlayerInput()
        {
            _movementDirection = new Vector3(-movementJoystick.Vertical, 0f, movementJoystick.Horizontal);
        }

        private void FixedUpdate()
        {
            if (MovementControl()) return;
            if (FighterControl()) return;
        }

        private bool FighterControl() =>  _fighter.StartFight();

        private bool MovementControl() => _movement.StartMoveAction(_movementDirection, Time.fixedDeltaTime);
        
    }
}