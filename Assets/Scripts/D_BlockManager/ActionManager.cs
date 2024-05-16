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
    public static Action<float> OnStartMoving;
    public static Action OnStepRight;
    public static Action OnStepLeft;
    public static Action OnJump;
    public static Action OnSlide;
    public static Action OnHitTheWall;
    public static Action OnFallInPit;

    //Collectables
    public static Action<int> OnCollectCoin;
    public static Action OnCollectPerk;
}
