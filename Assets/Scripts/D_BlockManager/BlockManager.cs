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
        [SerializeField] private float speed;
        [SerializeField] private bool inMove;
        [SerializeField] private bool canMove;
        public bool canBeUsed;
        public bool singleUse;

        [SerializeField] private GameObject obstacleFolder;
        [SerializeField] private List<GameObject> obstaclePool;
        [SerializeField] private GameObject collectableFolder;
        [SerializeField] private List<GameObject> collectablePool;

        private void Awake()
        {
            ResetClass();
        }
        private void Update()
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
                ResetBlock();
            }
        }
        private void ToggleMove(float moveSpeed, bool willMove)
        {
            inMove = willMove;
            speed = moveSpeed;
        }
        public void PlaceOnScene()
        {
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
            gameObject.SetActive(false);
        }
        private void ResetClass()
        {
            ActionManager.OnToggleMoving += ToggleMove;

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
            if (!singleUse)
            {
                ResetBlock();
            }
        }
        private void OnEnable()
        {
            canBeUsed = false;
            inMove = true;
            ActionManager.StartNewGame += ResetClass;
        }
        private void OnDisable()
        {
            canBeUsed = true;
            inMove = false;
            ActionManager.StartNewGame -= ResetClass;
        }
        private void OnDestroy()
        {
            ActionManager.OnToggleMoving -= ToggleMove;
        }
    }
}