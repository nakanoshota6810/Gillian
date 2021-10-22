using System.Collections;
using System.Collections.Generic;


/// <summary>
/// �ÓI�N���X
/// �X�R�A�f�[�^���Ǘ�
/// </summary>
static public class Score 
{
    // �u���b�N���󂵂����̃J�E���g�̐ÓI�ϐ�
    static public int blockBreakCount { get; private set; }

    // �R���{���̃J�E���g�̐ÓI�ϐ�
    static public int comboCount { get; private set; }

    // �ő�R���{���̃J�E���g�̐ÓI�ϐ�
    static public int maxComboCount { get; private set; }

    // �X�R�A�l�̐ÓI�ϐ�
    static public int score { get; private set; }

    //�^�C���J�E���g�@�\���g�p���邽�߂̐ÓI�C���X�^���X
    static private Timer timeCountChack;

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

        //9999������Ƃ���
        if (blockBreakCount > 9999) blockBreakCount = 9999;
    }

    /// <summary>
    /// �R���{�J�E���g�̃C���N�������g
    /// </summary>
    static private void ComboCountAdd()
    {
        comboCount++;

        //9999������Ƃ���
        if (comboCount > 9999) comboCount = 9999;

        //�ő�R���{���̍X�V
        if (maxComboCount < comboCount) maxComboCount = comboCount;
    }

    /// <summary>
    /// �X�R�A�̉��Z
    /// </summary>
    static private void ScoreAdd()
    {
        score += 1 * comboCount;

        //999999������Ƃ���
        if (score > 999999) score = 999999;
    }

    /// <summary>
    /// �u���b�N��j�󂵂��Ƃ��̃X�R�A���Z����
    /// </summary>
    static public void AddScores()
    {
        BlockBreakCountAdd();
        ComboCountAdd();
        ScoreAdd();

        //�J�E���g�_�E���@�\�������Ă��Ȃ��Ƃ��A���Z�b�g����
        if (timeCountChack != null)
            timeCountChack.CountReset();
    }

    /// <summary>
    /// ��莞�Ԃ��ƂɁA�R���{�������Z�b�g����
    /// </summary>
    static public void UpdateChackComboAlive()
    {
        if (timeCountChack == null) timeCountChack = new Timer(5);
        if (timeCountChack.ChackTime())
            comboCount = 0;
    }
}
