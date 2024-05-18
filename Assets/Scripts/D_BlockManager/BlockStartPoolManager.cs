using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStartPoolManager : MonoBehaviour
{
    [SerializeField] private GameObject[] startBlock;
    private Vector3 startPosition1 = new Vector3(0f,0f,0f);
    private Vector3 startPosition2 = new Vector3(0f,0f,-60f);

    private void Awake()
    {
        ResetClass();
    }
    private void ResetClass()
    {
        startBlock[0].gameObject.SetActive(true);
        startBlock[1].gameObject.SetActive(true);
        startBlock[0].transform.position = startPosition1;
        startBlock[1].transform.position = startPosition2;
    }
    private void OnEnable()
    {
        ActionManager.StartNewGame += ResetClass;
    }
    private void OnDisable()
    {
        ActionManager.StartNewGame -= ResetClass;
    }
}
