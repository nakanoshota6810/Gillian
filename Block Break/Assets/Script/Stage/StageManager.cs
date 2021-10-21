using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロック群の管理機能
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


