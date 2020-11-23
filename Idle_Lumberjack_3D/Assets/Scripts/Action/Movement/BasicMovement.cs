using Lumberjack.Stats;
using System.Collections.Generic;
using UnityEngine;

namespace Lumberjack.Actions.Movement
{
    [RequireComponent(typeof(CharacterController),typeof(ActionScheduler))]
    public class BasicMovement : MonoBehaviour, IAction
    {
        [SerializeField] private Animator animator;
        [SerializeField] private BaseStats baseStats;

        private ActionScheduler _actionScheduler;
        private CharacterController _characterController;
     
        private Vector3 _currentMoveDirection;

        public float currentSpeed
        {
            get { return  baseStats.GetStat(Stat.Speed); }
        }
   

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _actionScheduler = GetComponent<ActionScheduler>();
        }
        public bool StartMoveAction(Vector3 direction,float deltaTime)
        {
            if (direction.magnitude == 0f) 
            {
                Cancel();
                return false; 
            }

            _currentMoveDirection = direction;
            _actionScheduler.StartAction(this);
           
            RotateInDirection();
            MoveInDirection(deltaTime);
            UpdateAnimator();
            return true;
        }
        private void MoveInDirection(float deltaTime)
        {
            _characterController.enabled = true;
           
            _characterController.Move(_currentMoveDirection * currentSpeed * deltaTime);
        }
        private void RotateInDirection()
        {
            if(_currentMoveDirection.magnitude != 0f)
            {
                transform.forward = _currentMoveDirection;
            }
        }
        private void UpdateAnimator()
        {
            if (animator != null)
            {
                animator.SetFloat("ForwardSpeed", _currentMoveDirection.magnitude);
            }
        }
      
        public void Cancel()
        {
            _characterController.enabled = false;
            if (animator != null)
            {
                animator.SetFloat("ForwardSpeed", 0);
            }
        }
    }
}