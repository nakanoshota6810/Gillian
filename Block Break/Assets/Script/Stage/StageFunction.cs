using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFunction 
{
    private StageFunctionBase stageFunctionBase;

    MainGameStatus nowMainGameStatus;

    public StageFunction()
    {
        nowMainGameStatus = GameManager.statusNo;
        stageFunctionBase = null;

        ChangeGameStatus();
    }

    public void ItStart()
    {
        if (stageFunctionBase != null)
            stageFunctionBase.ItStart();
    }

    public void ItUpdate()
    {
        if (nowMainGameStatus != GameManager.statusNo)
        {
            ChangeGameStatus();
        }

        if (stageFunctionBase != null)
            stageFunctionBase.ItUpdate();
    }

    void ChangeGameStatus()
    {
        stageFunctionBase = null;

        switch (GameManager.statusNo)
        {
            case MainGameStatus.Title:
                break;

            case MainGameStatus.Ready:
                stageFunctionBase = new StageFunctionSetStartBlocks();
                ItStart();
                break;

            case MainGameStatus.InGameNormal:
                stageFunctionBase = new StageFunctionBlockSpawn();
                ItStart();
                break;

            case MainGameStatus.InGameWarning:
                break;

            case MainGameStatus.GameOver:
                break;

            default:
                break;
        }

        nowMainGameStatus = GameManager.statusNo;

    }
}
