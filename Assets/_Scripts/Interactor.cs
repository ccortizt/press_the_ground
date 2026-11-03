using UnityEngine;
using UnityEngine.InputSystem;

namespace SandAttack.Gameplay
{
    public class Interactor : MonoBehaviour
    {
        private void Update()
        {
            if (!Mouse.current.leftButton.isPressed) return;

            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawLine(ray.origin, hit.point);
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}