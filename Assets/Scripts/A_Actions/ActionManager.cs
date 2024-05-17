using DGeneration;
using System;
using UnityEngine;

public static class ActionManager
{
    //Generator Manager
    public static Action OnTouchLevelEnd;
    public static Action OnTouchLevelStart;
    public static Action ActivateSomeBlocks;

    //Player Related
    public static Action<float, bool> OnToggleMoving;
    public static Action OnHitObstacle;

    //Collectables
    public static Action<int> OnCollectCoin;
    public static Action OnCollectPerk;
}
