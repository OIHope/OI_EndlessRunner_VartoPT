using DGeneration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStartPoolManager : MonoBehaviour
{
    [SerializeField] private GameObject[] startBlock;
    private Vector3 startPosition1 = new Vector3(0f,0f,0f);
    private Vector3 startPosition2 = new Vector3(0f,0f,-60f);

    private void ResetBlockStartPoolClass()
    {
        startBlock[0].gameObject.SetActive(true);
        startBlock[1].gameObject.SetActive(true);
        startBlock[0].transform.position = startPosition1;
        startBlock[1].transform.position = startPosition2;
        Debug.Log("BlockStartPool is RESET");
    }
    private void ToggleBlockMove(float speed, bool inMove)
    {
        foreach (var block in startBlock)
        {
            block.GetComponent<BlockManager>().speed = speed;
            block.GetComponent<BlockManager>().inMove = inMove;
        }
    }
    private void OnEnable()
    {
        ResetBlockStartPoolClass();
        ActionManager.OnToggleMoving += ToggleBlockMove;
        ActionManager.StartNewGame += ResetBlockStartPoolClass;
    }
    private void OnDisable()
    {
        ActionManager.OnToggleMoving -= ToggleBlockMove;
        ActionManager.StartNewGame -= ResetBlockStartPoolClass;
    }
}
