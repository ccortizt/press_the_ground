using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SandAttack.Gameplay
{
    public class BarMover : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float minYPosition = -2f;

        private float initialYPosition;

        private void Start()
        {
            initialYPosition = transform.localPosition.y;
        }

        public void Move(float deltaYMovement)
        {
            var newPosition = transform.localPosition + Vector3.up * deltaYMovement;
            newPosition.y = Mathf.Clamp(newPosition.y, minYPosition, initialYPosition);
            transform.localPosition = newPosition;
        }

        private void Update()
        {
            if (Keyboard.current.uKey.isPressed)
                Move(speed * Time.deltaTime);
            if (Keyboard.current.iKey.isPressed)
                Move(-speed * Time.deltaTime);
        }
    }
}