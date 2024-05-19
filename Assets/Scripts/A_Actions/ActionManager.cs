using System;

public static class ActionManager
{
    //GAMELOOP
    public static Action StartNewGame;
    public static Action<bool> PauseGame;
    public static Action StopGame;

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

    //Collectables
    public static Action<int> OnCollectCoin;
    public static Action OnHitFood;
    public static Action OnFillFoodBar;


    //UI SidePanel
    public static Action<int> UIFoodValueChanged;
    public static Action<int> UIHeartValueChanged;
    public static Action<int, int> UITimeValueChanged;

    //IU Input
    public static Action UIToggleSidePanel;
    public static Action UITogglePausePanel;

    //ScoreRelated
    public static Action OnSecondPass;
    public static Action<int,int,int,int,int> FinalScoreUdpate;
    public static Action tempGameOverEnable;
}
