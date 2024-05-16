using UnityEngine;

namespace BData
{
    [System.Serializable]
    public class BlockData
    {
        public Enviroment enviroment;
        public Difficulty difficulty;
        public Vector3 spawnPosition;
        public float speed;
        public bool currentlyUsed;
        public bool canBeUsed;
    }
}