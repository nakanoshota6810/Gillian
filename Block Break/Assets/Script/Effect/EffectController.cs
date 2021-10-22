using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スーパーブレイク時の衝撃波エフェクトを管理する
/// </summary>
public class EffectController : MonoBehaviour
{
    //移動スピードを格納
    [SerializeField] private float moveSpeed;

    //移動向きを格納する
    private Vector3 moveVector;

    // Update is called once per frame
    void Update()
    {
        //移動向きに移動スピード分移動
        transform.position += moveVector * moveSpeed;

        //一定まで移動することで、衝撃波を消滅
        if (transform.position.x < -60 || transform.position.x > 60 || transform.position.y > 80)
            Destroy(this.gameObject);
    }

    /// <summary>
    /// 移動方向と出現場所を受け取る
    /// </summary>
    /// <param 移動向き="moveVec"></param>
    /// <param 出現場所="alivepPosition"></param>
    public void SetVectors(Vector3 moveVec, Vector3 alivepPosition)
    {
        moveVector = moveVec;
        transform.position = alivepPosition;
    }
}

