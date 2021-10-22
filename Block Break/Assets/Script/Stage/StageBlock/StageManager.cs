using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージ全体の管理機能
/// </summary>
public class StageManager : MonoBehaviour
{
    //ステージ毎の機能を管理するクラスを宣言
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


