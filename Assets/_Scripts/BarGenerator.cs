using UnityEngine;

namespace PressTheGround.Gameplay
{
    public class BarGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject barPrefab;
        [SerializeField] private GameObject barsPlanePrefab;
        [SerializeField] private SpawnerData spawnerData;

        private float barThickness = 0.5f;
        private float planeScale = 1f;

        private void Start()
        {
            foreach (BoxData spawnData in spawnerData.Datas)
            {
                var barsArea = Instantiate(new GameObject(), transform);
                barsArea.name = $"Bars_({spawnData.MinX},{spawnData.MinZ})_({spawnData.MaxX},{spawnData.MaxZ})";

                var barsPlane = Instantiate(barsPlanePrefab, barsArea.transform);
                barsPlane.transform.position += Vector3.up * barPrefab.transform.localScale.y / 2;
                var planeXScale = Mathf.Abs(spawnData.MaxX - spawnData.MinX) * planeScale + 1;
                var planeZScale = Mathf.Abs(spawnData.MaxZ - spawnData.MinZ) * planeScale + 1;

                barsPlane.transform.localScale = new Vector3(planeXScale, barsPlane.transform.localScale.y, planeZScale);
                
                for (int i = spawnData.MinX; i <= spawnData.MaxX; i++)
                {
                    for (int j = spawnData.MinZ; j <= spawnData.MaxZ; j++)
                        Spawn(i, spawnData.Y, j, barsArea.transform);
                }
            }
        }

        private void Spawn(float x, float y, float z, Transform parent)
        {
            Instantiate(barPrefab, new Vector3(x * barThickness, y, z * barThickness), Quaternion.identity, parent);
        }
    }
}