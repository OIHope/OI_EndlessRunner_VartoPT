using UnityEngine;
using System;
using BData;

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

        private void Awake()
        {
            ActionManager.OnStartMoving += StartMove;
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
        private void StartMove(float moveSpeed)
        {
            inMove = true;
            speed = moveSpeed;
            ActionManager.OnStartMoving -= StartMove;
        }
        public void PlaceOnScene()
        {
            gameObject.SetActive(true);
        }
        private void ResetBlock()
        {
            transform.position = spawnPosition;
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