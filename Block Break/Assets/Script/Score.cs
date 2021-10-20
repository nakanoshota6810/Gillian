using System.Collections;
using System.Collections.Generic;


/// <summary>
/// スコアデータを管理
/// </summary>
static public class Score 
{
    // ブロックを壊した数のカウント
    static public int blockBreakCount { get; private set; }

    // コンボ数のカウント
    static public int comboCount { get; private set; }

    // 最大コンボ数のカウント
    static public int maxComboCount { get; private set; }

    // スコア値
    static public int score { get; private set; }

    //タイムカウント機能を使用するためのインスタンス
    static private TimeCountChack timeCountChack;

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
        if (blockBreakCount > 9999) blockBreakCount = 9999;
    }

    /// <summary>
    /// スコアの加算
    /// </summary>
    static private void ScoreAdd()
    {
        score += 1 * comboCount;
        if (score > 999999) score = 9999;
    }

    /// <summary>
    /// コンボカウントのインクリメント
    /// </summary>
    static private void ComboCountAdd()
    {
        comboCount++;
        if (comboCount > 9999) comboCount = 9999;
        if (maxComboCount < comboCount) maxComboCount = comboCount;
    }

    /// <summary>
    /// ブロックを破壊したときの処理
    /// </summary>
    static public void BlockbreakCountAndScorePointAdd()
    {
        BlockBreakCountAdd();
        ComboCountAdd();
        ScoreAdd();
        if (timeCountChack != null)
            timeCountChack.CountReset();
    }

    /// <summary>
    /// 一定時間ごとに、コンボ数をリセットする
    /// </summary>
    static public void UpdateChackComboAlive()
    {
        if (timeCountChack == null) timeCountChack = new TimeCountChack(5);
        if (timeCountChack.ChackTime())
            comboCount = 0;
    }
}
