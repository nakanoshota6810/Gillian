
/// <summary>
/// ゲームステータスの列挙型
/// </summary>
public enum MainGameStatus
{
    Nome = 0,
    Ready,          //ゲーム開始前
    InGameNormal,   //通常状態でゲーム中
    InGameWarning,  //危険状態(プレイヤー消滅状態)でゲーム中
    GameOver,       //ゲームオーバー
}
