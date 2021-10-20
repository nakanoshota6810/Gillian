
/// <summary>
/// �Q�[���X�e�[�^�X�̗񋓌^
/// </summary>
public enum MainGameStatus
{
    Nome = 0,
    Title,          //�^�C�g��
    Ready,          //�Q�[���J�n�O
    InGameNormal,   //�ʏ��ԂŃQ�[����
    InGameWarning,  //�댯���(�v���C���[���ŏ��)�ŃQ�[����
    GameOver,       //�Q�[���I�[�o�[
}


public enum GameMode 
{
    Nome=0,
    NormalMode,     //�ʏ�Q�[�����[�h
    TimeColorMode,  //�^�C���J���[�Q�[�����[�h
    WideMode        //���C�h�Q�[�����[�h
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


