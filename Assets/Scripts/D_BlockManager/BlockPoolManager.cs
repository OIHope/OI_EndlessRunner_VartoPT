using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DGeneration
{
    public class BlockPoolManager : MonoBehaviour
    {
        [SerializeField] private List<BlockManager> blockPool;
        [SerializeField] private int firstBlockID = 0;
        [SerializeField] private int midBlockID = 1;
        [SerializeField] private int lastBlockID = 2;

        private void Awake()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                BlockManager child = transform.GetChild(i).transform.GetComponent<BlockManager>();
                if (!child.singleUse)
                {
                    blockPool.Add(child);
                }
            }
        }
        private void Start()
        {
            PickBlockToSpawn();
        }
        private void PickBlockToSpawn()
        {
            GetRandomBlockID(firstBlockID, midBlockID, lastBlockID);
            blockPool[firstBlockID].PlaceOnScene();
        }
        private void GetRandomBlockID(int first, int mid, int last)
        {
            midBlockID = first;
            lastBlockID = mid;
            firstBlockID = Random.Range(0, blockPool.Count);
            while (firstBlockID == first || firstBlockID == mid || firstBlockID == last)
            {
                firstBlockID = Random.Range(0, blockPool.Count);
            }
        }
        private void OnEnable()
        {
            ActionManager.OnTouchLevelStart += PickBlockToSpawn;
        }
        private void OnDisable()
        {
            ActionManager.OnTouchLevelStart -= PickBlockToSpawn;
        }
    }
}