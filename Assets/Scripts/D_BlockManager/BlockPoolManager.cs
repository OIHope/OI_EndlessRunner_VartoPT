using BData;
using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace DGeneration
{
    public class BlockPoolManager : MonoBehaviour
    {
        [SerializeField] private int nextTypeStep = 10;
        private int currentTypeStep = 0;
        private int currentListID, listCount;

        private Dictionary<Enviroment, List<BlockManager>> blockDictionary = new();
        [SerializeField] private List<BlockManager> blockPool = new();
        [SerializeField] private List<BlockManager> canUsePool = new();

        private void PickBlockToSpawn()
        {
            GetRandomBlockID((Enviroment)GetListID()).PlaceOnScene();
            currentTypeStep++;
        }
        private BlockManager GetRandomBlockID(Enviroment ListID)
        {
            canUsePool.Clear();
            var poolList = blockDictionary[ListID];
            foreach (var block in poolList)
            {
                if (block.canBeUsed)
                    canUsePool.Add(block);
            }
            return canUsePool[Random.Range(0, canUsePool.Count)];
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
        private void ResetBlockPoolClass()
        {
            blockDictionary.Clear();
            blockPool.Clear();
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject thisPool = transform.GetChild(i).gameObject;
                for (int j = 0; j < thisPool.transform.childCount; j++)
                {
                    BlockManager child = thisPool.transform.GetChild(j).transform.GetComponent<BlockManager>();
                    if (thisPool.transform.childCount != 0 && !child.singleUse)
                    {
                        blockPool.Add(child);
                        child.RemoveFromScene();
                    }
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
        private void ToggleBlockMove(float speed, bool inMove)
        {
            foreach (var block in blockPool)
            {
                block.speed = speed;
                block.inMove = inMove;
            }
        }
        private void OnEnable()
        {
            ResetBlockPoolClass();
            ActionManager.OnToggleMoving += ToggleBlockMove;
            ActionManager.OnTouchLevelStart += PickBlockToSpawn;
            ActionManager.StartNewGame += ResetBlockPoolClass;
        }
        private void OnDisable()
        {
            ActionManager.OnToggleMoving -= ToggleBlockMove;
            ActionManager.OnTouchLevelStart -= PickBlockToSpawn;
            ActionManager.StartNewGame -= ResetBlockPoolClass;
        }
    }
}