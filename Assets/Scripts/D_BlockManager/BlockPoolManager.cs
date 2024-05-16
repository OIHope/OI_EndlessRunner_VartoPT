using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DGeneration
{
    public class BlockPoolManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> blockPool;
        [SerializeField] private int lastBlockID;

        private void Awake()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                blockPool.Add(child);
            }
        }
        private void Start()
        {
            PickBlockToSpawn();
        }
        private void PickBlockToSpawn() // DOESNT WORK!!!!
        {
            int randomID = Random.Range(0, blockPool.Count);
            bool avaliable = blockPool[randomID].transform.GetComponent<BlockManager>().blockData.canBeUsed;

            while (!avaliable)
            {
                randomID = Random.Range(0, blockPool.Count);
                avaliable = blockPool[randomID].transform.GetComponent<BlockManager>().blockData.canBeUsed;
            }

            blockPool[randomID].SetActive(true);
        }
        private void OnEnable()
        {
            //ActionManager.OnTouchLevelEnd += PickBlockToSpawn;
            ActionManager.OnTouchLevelStart += PickBlockToSpawn;
        }
        private void OnDisable()
        {
            //ActionManager.OnTouchLevelEnd -= PickBlockToSpawn;
            ActionManager.OnTouchLevelStart -= PickBlockToSpawn;
        }
    }
}