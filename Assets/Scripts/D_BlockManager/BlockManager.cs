using UnityEngine;
using System;
using BData;
using System.Collections.Generic;

namespace DGeneration
{
    public class BlockManager : MonoBehaviour
    {
        public Enviroment enviroment;
        public Difficulty difficulty;
        public Vector3 spawnPosition;
        [SerializeField] private float speed;
        [SerializeField] private bool inMove;
        [SerializeField] private bool canMove;
        public bool singleUse;

        [SerializeField] private GameObject obstacleFolder;
        [SerializeField] private List<GameObject> obstaclePool;

        private void Awake()
        {
            for (int i = 0; i < obstacleFolder.transform.childCount; i++)
            {
                GameObject child = obstacleFolder.transform.GetChild(i).gameObject;
                obstaclePool.Add(child);
            }
            ActionManager.OnToggleMoving += ToggleMove;
            if (!singleUse)
            {
                ResetBlock();
            }
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
            if (singleUse && other.transform.tag == "TriggerDestroy")
            {
                Destroy(gameObject);
            }
            if (!singleUse && other.transform.tag == "TriggerStart")
            {
                ActionManager.OnTouchLevelStart?.Invoke();
            }
            if (!singleUse && other.transform.tag == "TriggerDestroy")
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
            gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            inMove = true;
        }
        private void OnDisable()
        {
            inMove = false;
        }
    }
}