/*
    列挙型はすべてここに記載
*/


/// <summary>
/// ゲームステータスの列挙型
/// </summary>
public enum GameStatus
{
    Nome = 0,
    Title,          //タイトル
    Ready,          //ゲーム開始前
    InGameNormal,   //通常状態でゲーム中
    InGameWarning,  //危険状態(プレイヤー消滅状態)でゲーム中
    GameOver,       //ゲームオーバー
}

/// <summary>
/// ゲームモードの列挙型
/// </summary>
public enum GameMode 
{
    Nome=0,
    NormalMode,     //通常ゲームモード
    TimeColorMode,  //タイムカラーゲームモード
    WideMode        //ワイドゲームモード
}

/// <summary>
/// ゲーム内で使用する色の列挙型
/// </summary>
public enum ColorPallet
{
    Nome = 0,
    Red,        //赤
    Green,      //緑
    Blue,       //青
    Yellow,     //イエロー
    Magenta,    //マゼンタ
    Cyan        //シアン
}

/// <summary>
/// ブロック単体のステータスの列挙型
/// </summary>
public enum BlockStatus
{
    None = 0,   
    Fall,       //出現直後の落下速度が早い状態
    Alive,      //玉と接触できる生存状態
    Break,      //通常の消滅待ち状態
    SuperBreak  //衝撃波混みの消滅待ち状態
}


