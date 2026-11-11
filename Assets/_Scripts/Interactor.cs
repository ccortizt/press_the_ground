using UnityEngine;
using UnityEngine.InputSystem;

namespace SandAttack.Gameplay
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private LayerMask interactionLayer;

        private BarMover currentBarMover;

        private void Update()
        {
            if (Mouse.current.leftButton.isPressed)
            {
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100, interactionLayer))
                {
                    if (hit.collider.gameObject.TryGetComponent(out BarMover barMover))
                    {
                        if (currentBarMover != null)
                        {
                            currentBarMover.Release();
                            currentBarMover = null;
                        }

                        currentBarMover = barMover;
                        currentBarMover.Press();
                        return;
                    }
                }
            }

            if (currentBarMover == null) return;

            currentBarMover.Release();
            currentBarMover = null;
        }
    }
}