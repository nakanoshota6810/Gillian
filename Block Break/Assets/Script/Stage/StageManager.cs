using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �u���b�N�Q�̊Ǘ��@�\
/// </summary>
public class StageManager : MonoBehaviour
{
    private StageFunction stageFunction;

    private void Start()
    {
        stageFunction = new StageFunction();
        stageFunction.ItStart();
    }

    private void Update()
    {
        stageFunction.ItUpdate();
    }

}


