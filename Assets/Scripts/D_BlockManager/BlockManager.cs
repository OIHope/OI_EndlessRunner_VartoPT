using UnityEngine;
using System;
using BData;

namespace DGeneration
{
    public class BlockManager : MonoBehaviour
    {
        public BlockData blockData = new BlockData();

        private void Awake()
        {
            ReserBlock();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == "TriggerStart")
            {
                ActionManager.OnTouchLevelStart?.Invoke();
            }
            if (other.transform.tag == "TriggerDestroy")
            {
                //ActionManager.OnTouchLevelEnd?.Invoke();
                ReserBlock();
                
            }
        }
        private void ReserBlock()
        {
            transform.position = blockData.spawnPosition;
            gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            blockData.currentlyUsed = true;
            blockData.canBeUsed = false;
        }
        private void OnDisable()
        {
            blockData.currentlyUsed = false;
            blockData.canBeUsed = true;
        }
    }
}