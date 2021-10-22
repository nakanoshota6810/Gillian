using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 静的クラス
/// スコアデータを管理
/// </summary>
static public class Score 
{
    // ブロックを壊した数のカウントの静的変数
    static public int blockBreakCount { get; private set; }

    // コンボ数のカウントの静的変数
    static public int comboCount { get; private set; }

    // 最大コンボ数のカウントの静的変数
    static public int maxComboCount { get; private set; }

    // スコア値の静的変数
    static public int score { get; private set; }

    //タイムカウント機能を使用するための静的インスタンス
    static private Timer timeCountChack;

    /// <summary>
    /// スコアの初期化
    /// </summary>
    static public void ResetScore()
    {
        blockBreakCount = 0;
        comboCount = 0;
        maxComboCount = 0;
        score = 0;
    }

    /// <summary>
    /// ブロック破壊カウントのインクリメント
    /// </summary>
    static private void BlockBreakCountAdd()
    {
        blockBreakCount++;

        //9999を上限とする
        if (blockBreakCount > 9999) blockBreakCount = 9999;
    }

    /// <summary>
    /// コンボカウントのインクリメント
    /// </summary>
    static private void ComboCountAdd()
    {
        comboCount++;

        //9999を上限とする
        if (comboCount > 9999) comboCount = 9999;

        //最大コンボ数の更新
        if (maxComboCount < comboCount) maxComboCount = comboCount;
    }

    /// <summary>
    /// スコアの加算
    /// </summary>
    static private void ScoreAdd()
    {
        score += 1 * comboCount;

        //999999を上限とする
        if (score > 999999) score = 999999;
    }

    /// <summary>
    /// ブロックを破壊したときのスコア加算処理
    /// </summary>
    static public void AddScores()
    {
        BlockBreakCountAdd();
        ComboCountAdd();
        ScoreAdd();

        //カウントダウン機能が動いていないとき、リセットする
        if (timeCountChack != null)
            timeCountChack.CountReset();
    }

    /// <summary>
    /// 一定時間ごとに、コンボ数をリセットする
    /// </summary>
    static public void UpdateChackComboAlive()
    {
        if (timeCountChack == null) timeCountChack = new Timer(5);
        if (timeCountChack.ChackTime())
            comboCount = 0;
    }
}
