using System.Collections.Generic;
using UnityEngine;

namespace PressTheGround.Gameplay
{
    [RequireComponent(typeof(Collider))]
    public class GroundPresserVolume : MonoBehaviour
    {
        private readonly HashSet<BarMover> currentBars = new();

        private void OnTriggerEnter(Collider other)
        {
            BarMover bar = other.gameObject.GetComponent<BarMover>();
            if (bar == null) return;

            currentBars.Add(bar);
            bar.Press();
        }

        private void OnTriggerExit(Collider other)
        {
            BarMover bar = other.gameObject.GetComponent<BarMover>();
            if (bar == null) return;

            if (currentBars.Contains(bar))
            {
                bar.Release();
                currentBars.Remove(bar);
            }
        }

       
    }
}