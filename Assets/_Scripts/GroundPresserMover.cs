using UnityEngine;
using UnityEngine.InputSystem;

namespace PressTheGround.Gameplay
{
    public class GroundPresserMover : MonoBehaviour
    {
        [SerializeField] private LayerMask interactionLayer;
        [SerializeField] private GameObject groundPresser;

        private void Start()
        {
            groundPresser.SetActive(false);
        }

        private void Update()
        {
            if (Keyboard.current.anyKey.isPressed)
            {
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

                if (Physics.Raycast(ray, out var hit, 100, interactionLayer))
                {
                    groundPresser.SetActive(true);
                    groundPresser.transform.position = hit.point;
                    return;
                }
            }
            
            groundPresser.SetActive(false);
        }
    }
}