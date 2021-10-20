
/// <summary>
/// ゲームステータスの列挙型
/// </summary>
public enum MainGameStatus
{
    Nome = 0,
    Title,          //タイトル
    Ready,          //ゲーム開始前
    InGameNormal,   //通常状態でゲーム中
    InGameWarning,  //危険状態(プレイヤー消滅状態)でゲーム中
    GameOver,       //ゲームオーバー
}


public enum GameMode 
{
    Nome=0,
    NormalMode,     //通常ゲームモード
    TimeColorMode,  //タイムカラーゲームモード
    WideMode        //ワイドゲームモード
}


public enum ColorPallet
{
    Nome = 0,
    Red = 1,
    Green = 2,
    Blue = 3,
    Yellow = 4,
    Magenta = 5,
    Cyan = 6,
    ColorMax = 7
}

public enum BlockStatus
{
    None=0,
    Fall,
    Alive
}


