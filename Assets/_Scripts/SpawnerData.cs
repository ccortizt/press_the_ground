using System.Collections.Generic;
using UnityEngine;

namespace SandAttack.Gameplay
{
    [CreateAssetMenu(fileName = "SpawnerData", menuName = "ScriptableObjects/SpawnerData")]
    public class SpawnerData : ScriptableObject
    {
        [SerializeField] private List<BoxData> datas;
        
        public  List<BoxData> Datas => datas;
    }

    [System.Serializable]
    public class BoxData
    {
        public int MinX;
        public int MinZ;
        public int MaxX;
        public int MaxZ;
        public int Y;

        public (int, int, int, int, int) ToSpawn() => (MinX, MinZ,MaxX, MaxZ, Y);
    }
}