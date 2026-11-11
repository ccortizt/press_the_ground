using UnityEngine;

namespace PressTheGround.Gameplay
{
    public class BarMover : MonoBehaviour
    {
        [SerializeField] private float pressSpeed = 1f;
        [SerializeField] private float relaseSpeed = .5f;
        [SerializeField] private float minYPosition = -2f;

        private float initialYPosition;
        private bool isPressed;

        private void Start()
        {
            initialYPosition = transform.localPosition.y;
        }

        private void Move(float deltaYMovement)
        {
            var newPosition = transform.localPosition + Vector3.up * deltaYMovement;
            newPosition.y = Mathf.Clamp(newPosition.y, minYPosition, initialYPosition);
            transform.localPosition = newPosition;
        }

        public void Press()
        {
            isPressed = true;
        }

        public void Release()
        {
            isPressed = false;
        }

        private void Update()
        {
            if (!isPressed)
            {
                Move(pressSpeed * Time.deltaTime);
                return;
            }

            Move(-relaseSpeed * Time.deltaTime);
        }
    }
}