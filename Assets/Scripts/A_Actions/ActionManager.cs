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

    public static Action OnStarving;
    public static Action OnLoseHeart;

    public static Action OnDeath;
    public static Action OnStartNewRun;


    //Collectables
    public static Action<int> OnCollectCoin;
    public static Action OnHitFood;
    public static Action OnFillFoodBar;


    //UI
    public static Action<int> UIFoodValueChanged;
    public static Action<int> UIHeartValueChanged;
    public static Action<string> UIGameStatusChanged;
}
