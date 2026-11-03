using UnityEngine;

namespace SandAttack.Gameplay
{
    public class BarGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject barPrefab;
        [SerializeField] private SpawnerData spawnerData;

        private float barOffset = 0.5f;

        private void Start()
        {
            foreach (BoxData spawnData in spawnerData.Datas)
            {
                for (int i = spawnData.MinX; i <= spawnData.MaxX; i++)
                for (int j = spawnData.MinZ; j <= spawnData.MaxZ; j++)
                    Spawn(i, spawnData.Y, j);
            }
        }

        private void Spawn(float x, float y, float z)
        {
            Instantiate(barPrefab, new Vector3(x * barOffset, y, z * barOffset), Quaternion.identity, transform);
        }
    }
}