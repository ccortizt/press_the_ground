using System.Collections.Generic;
using UnityEngine;

namespace PressTheGround.Gameplay
{
    [RequireComponent(typeof(Collider))]
    public class GroundPresserVolume : MonoBehaviour
    {
        [SerializeField] private float scalingSpeed = 2f;
        [SerializeField] private AnimationCurve animationCurve;
        [SerializeField] private float maxScaling = 2f;

        private readonly HashSet<BarMover> currentBars = new();

        private Vector3 initialScale;
        private float activeTime = 0f;

        private void Start()
        {
            initialScale = transform.localScale;
        }

        private void OnEnable()
        {
            transform.localScale = initialScale;
            activeTime = 0f;
        }

        private void Update()
        {
            activeTime += Time.deltaTime;
            activeTime = Mathf.Clamp01(activeTime);
            
            var newScale = transform.localScale + Vector3.one * 
                (Time.deltaTime * animationCurve.Evaluate(activeTime) * scalingSpeed);

            newScale = new Vector3(
                Mathf.Clamp(newScale.x, initialScale.x, maxScaling),
                Mathf.Clamp(newScale.y, initialScale.y, maxScaling),
                Mathf.Clamp(newScale.z, initialScale.z, maxScaling));

            transform.localScale = newScale;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out BarMover barMover)) return;

            currentBars.Add(barMover);
            barMover.Press();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out BarMover barMover)) return;
            if (!currentBars.Contains(barMover)) return;

            barMover.Release();
            currentBars.Remove(barMover);

        }

        private void OnDisable()
        {
            if (currentBars.Count <= 0) return;
          
            foreach (var bar in currentBars)
                bar.Release();

            currentBars.Clear();
        }
    }
}