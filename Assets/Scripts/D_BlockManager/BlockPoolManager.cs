using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using BData;

namespace DGeneration
{
    public class BlockPoolManager : MonoBehaviour
    {
        [SerializeField] private Dictionary<Enviroment, List<BlockManager>> blockDictionary = new();
        private List<BlockManager> blockPool = new();
        [SerializeField] private int firstBlockID = 0;
        [SerializeField] private int midBlockID = 1;
        [SerializeField] private int lastBlockID = 2;
        [Space]
        [SerializeField] private int currentListID, listCount;
        [SerializeField] private int nextTypeStep = 10;
        [SerializeField] private int currentTypeStep = 0;
        private void Awake()
        {
            ResetClass();
        }
        private void PickBlockToSpawn()
        {
            GetRandomBlockID(firstBlockID, midBlockID, lastBlockID, (Enviroment)GetListID());
            blockDictionary[(Enviroment)currentListID][firstBlockID].PlaceOnScene();
            currentTypeStep++;
        }
        private void GetRandomBlockID(int first, int mid, int last, Enviroment ListID)
        {
            var poolList = blockDictionary[ListID];
            midBlockID = first;
            lastBlockID = mid;
            firstBlockID = Random.Range(0, poolList.Count);
            while (firstBlockID == first || firstBlockID == mid || firstBlockID == last)
            {
                firstBlockID = Random.Range(0, poolList.Count);
            }
        }
        private int GetListID()
        {
            if (currentTypeStep >= nextTypeStep)
            {
                currentListID++;
                currentTypeStep = 0;
            }
            currentListID = currentListID > listCount ? 0 : currentListID;
            return currentListID;
        }
        private void ResetClass()
        {
            blockDictionary.Clear();
            blockPool.Clear();
            for (int i = 0; i < transform.childCount; i++)
            {
                BlockManager child = transform.GetChild(i).transform.GetComponent<BlockManager>();
                if (!child.singleUse)
                {
                    blockPool.Add(child);
                }
            }
            var blockGroup = blockPool.GroupBy(block => block.enviroment);
            foreach (var block in blockGroup)
            {
                if (!blockDictionary.ContainsKey(block.Key))
                {
                    blockDictionary[block.Key] = new List<BlockManager>();
                }
                blockDictionary[block.Key].AddRange(block);
            }
            listCount = blockDictionary.Keys.Count - 1;
            currentListID = 0;
            currentTypeStep = 0;
        }
        private void OnEnable()
        {
            ActionManager.OnTouchLevelStart += PickBlockToSpawn;
            ActionManager.StartNewGame += ResetClass;
        }
        private void OnDisable()
        {
            ActionManager.OnTouchLevelStart -= PickBlockToSpawn;
            ActionManager.StartNewGame -= ResetClass;
        }
    }
}