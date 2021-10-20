using System.Collections;
using System.Collections.Generic;


/// <summary>
/// �X�R�A�f�[�^���Ǘ�
/// </summary>
static public class Score 
{
    // �u���b�N���󂵂����̃J�E���g
    static public int blockBreakCount { get; private set; }

    // �R���{���̃J�E���g
    static public int comboCount { get; private set; }

    // �ő�R���{���̃J�E���g
    static public int maxComboCount { get; private set; }

    // �X�R�A�l
    static public int score { get; private set; }

    //�^�C���J�E���g�@�\���g�p���邽�߂̃C���X�^���X
    static private TimeCountChack timeCountChack;

    /// <summary>
    /// �X�R�A�̏�����
    /// </summary>
    static public void ResetScore()
    {
        blockBreakCount = 0;
        comboCount = 0;
        maxComboCount = 0;
        score = 0;
    }

    /// <summary>
    /// �u���b�N�j��J�E���g�̃C���N�������g
    /// </summary>
    static private void BlockBreakCountAdd()
    {
        blockBreakCount++;
        if (blockBreakCount > 9999) blockBreakCount = 9999;
    }

    /// <summary>
    /// �X�R�A�̉��Z
    /// </summary>
    static private void ScoreAdd()
    {
        score += 1 * comboCount;
        if (score > 999999) score = 9999;
    }

    /// <summary>
    /// �R���{�J�E���g�̃C���N�������g
    /// </summary>
    static private void ComboCountAdd()
    {
        comboCount++;
        if (comboCount > 9999) comboCount = 9999;
        if (maxComboCount < comboCount) maxComboCount = comboCount;
    }

    /// <summary>
    /// �u���b�N��j�󂵂��Ƃ��̏���
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
    /// ��莞�Ԃ��ƂɁA�R���{�������Z�b�g����
    /// </summary>
    static public void UpdateChackComboAlive()
    {
        if (timeCountChack == null) timeCountChack = new TimeCountChack(5);
        if (timeCountChack.ChackTime())
            comboCount = 0;
    }
}
