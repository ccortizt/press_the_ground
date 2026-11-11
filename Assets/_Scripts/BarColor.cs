using UnityEngine;

namespace PressTheGround.Gameplay
{
    public class BarColor : MonoBehaviour
    {
        private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");
        private Material barMaterial;
        private BarMover barMover;

        private void Start()
        {
            barMaterial = GetComponent<Renderer>().material;
            barMover = GetComponent<BarMover>();
        }

        private void Update()
        {
            barMaterial.SetColor(BaseColor, Color.Lerp(Color.black, Color.white, barMover.YProp));
        }
    }
}