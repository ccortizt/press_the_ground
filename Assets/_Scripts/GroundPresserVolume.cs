using System;
using System.Collections.Generic;
using UnityEngine;

namespace PressTheGround.Gameplay
{
    [RequireComponent(typeof(Collider))]
    public class GroundPresserVolume : MonoBehaviour
    {
        [SerializeField] private float scalingSpeed = 2f;
        [SerializeField] private float maxScaling = 2f;

        private readonly HashSet<BarMover> currentBars = new();

        private Vector3 initialScale;

        private void Start()
        {
            initialScale = transform.localScale;
        }

        private void OnEnable()
        {
            transform.localScale = initialScale;
        }

        private void Update()
        {
            var newScale = transform.localScale + Vector3.one * (Time.deltaTime * scalingSpeed);

            newScale = new Vector3(
                Mathf.Clamp(newScale.x, initialScale.x, maxScaling),
                Mathf.Clamp(newScale.y, initialScale.y, maxScaling),
                Mathf.Clamp(newScale.z, initialScale.z, maxScaling));

            transform.localScale = newScale;
        }

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
            
            if (!currentBars.Contains(bar)) return;
            
            bar.Release();
            currentBars.Remove(bar);
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