using System;
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
            if (Mouse.current.leftButton.isPressed)
            {
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100, interactionLayer))
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