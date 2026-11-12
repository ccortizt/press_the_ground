using UnityEngine;

namespace PressTheGround.Gameplay
{
    public class BarColor : MonoBehaviour
    {
        private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");
        
        private Material barMaterial;
        private BarMover barMover;
        private Color initialColor;

        private void Start()
        {
            barMaterial = GetComponent<Renderer>().material;
            initialColor = barMaterial.GetColor(BaseColor);
            barMover = GetComponent<BarMover>();
        }

        private void Update()
        {
            barMaterial.SetColor(BaseColor, Color.Lerp(initialColor, Color.white, barMover.YProp));
        }
    }
}