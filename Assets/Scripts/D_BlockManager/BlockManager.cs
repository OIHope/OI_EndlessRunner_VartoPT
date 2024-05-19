using UnityEngine;
using System;
using BData;
using System.Collections.Generic;

namespace DGeneration
{
    public class BlockManager : MonoBehaviour
    {
        public Enviroment enviroment;
        public Vector3 spawnPosition;
        public float speed;
        public bool inMove;
        [SerializeField] private bool canMove;
        public bool canBeUsed;
        public bool singleUse;

        [SerializeField] private GameObject obstacleFolder;
        [SerializeField] private List<GameObject> obstaclePool;
        [SerializeField] private GameObject collectableFolder;
        [SerializeField] private List<GameObject> collectablePool;

        private void FixedUpdate()
        {
            if (inMove)
            {
                MoveBlock();
            }
        }
        private void MoveBlock()
        {
            transform.position = new Vector3
                (transform.position.x, 
                transform.position.y, 
                transform.position.z - (speed * Time.deltaTime));
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == "TriggerStart")
            {
                ActionManager.OnTouchLevelStart?.Invoke();
            }
            if (other.transform.tag == "TriggerDestroy")
            {
                gameObject.SetActive(false);
            }
        }
        public void PlaceOnScene()
        {
            ResetBlock();
            canBeUsed = false;
            gameObject.SetActive(true);
        }
        private void ResetBlock()
        {
            transform.position = spawnPosition;
            foreach (GameObject obstacle in obstaclePool)
            {
                obstacle.SetActive(true);
            }
            foreach (GameObject obstacle in collectablePool)
            {
                obstacle.SetActive(true);
            }
            collectablePool.Clear();
            for (int i = 0; i < collectableFolder.transform.childCount; i++)
            {
                GameObject child = collectableFolder.transform.GetChild(i).gameObject;
                collectablePool.Add(child);
            }
            obstaclePool.Clear();
            for (int i = 0; i < obstacleFolder.transform.childCount; i++)
            {
                GameObject child = obstacleFolder.transform.GetChild(i).gameObject;
                obstaclePool.Add(child);
            }
        }
        private void ResetBlockManagerClass()
        {
            if (!singleUse)
            {
                ResetBlock();
            }
        }
        private void OnEnable()
        {
            ActionManager.StartNewGame += ResetBlockManagerClass;
        }
        private void OnDisable()
        {
            canBeUsed = true;
            ActionManager.StartNewGame -= ResetBlockManagerClass;
        }
    }
}