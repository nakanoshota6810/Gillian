/*
    �񋓌^�͂��ׂĂ����ɋL��
*/


/// <summary>
/// �Q�[���X�e�[�^�X�̗񋓌^
/// </summary>
public enum GameStatus
{
    Nome = 0,
    Title,          //�^�C�g��
    Ready,          //�Q�[���J�n�O
    InGameNormal,   //�ʏ��ԂŃQ�[����
    InGameWarning,  //�댯���(�v���C���[���ŏ��)�ŃQ�[����
    GameOver,       //�Q�[���I�[�o�[
}

/// <summary>
/// �Q�[�����[�h�̗񋓌^
/// </summary>
public enum GameMode 
{
    Nome=0,
    NormalMode,     //�ʏ�Q�[�����[�h
    TimeColorMode,  //�^�C���J���[�Q�[�����[�h
    WideMode        //���C�h�Q�[�����[�h
}

/// <summary>
/// �Q�[�����Ŏg�p����F�̗񋓌^
/// </summary>
public enum ColorPallet
{
    Nome = 0,
    Red,        //��
    Green,      //��
    Blue,       //��
    Yellow,     //�C�G���[
    Magenta,    //�}�[���^
    Cyan        //�V�A��
}

/// <summary>
/// �u���b�N�P�̂̃X�e�[�^�X�̗񋓌^
/// </summary>
public enum BlockStatus
{
    None = 0,   
    Fall,       //�o������̗������x���������
    Alive,      //�ʂƐڐG�ł��鐶�����
    Break,      //�ʏ�̏��ő҂����
    SuperBreak  //�Ռ��g���݂̏��ő҂����
}


