using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロックの色毎の機能を管理する
/// </summary>
public class BlockColorFunction
{
    //ブロックの色毎の機能の親クラス
    BlockColorFunctionBase blockColorFanctionBase;

    //ブロックのRendererを格納する
    private Renderer renderer;

    //ブロックのBlockDataを格納する
    private BlockData blockData;

    //ブロックの色の変更を感知する変数の宣言
    private ColorPallet nowColor;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param 自身のRendererのインスタンス="rr"></param>
    /// <param 自身のBlockDataのインスタンス="bd"></param>
    public BlockColorFunction(Renderer rr, BlockData bd)
    {
        renderer = rr;
        blockData = bd;
    }

    /// <summary>
    /// 玉と接触したときの更新処理
    /// </summary>
    /// <param 玉の当たり判定="collision"></param>
    public void HitUpdate(Collision collision)
    {
        if (blockColorFanctionBase != null)
            blockColorFanctionBase.HitUpdate(collision);
    }

    /// <summary>
    /// 初期化時のブロックの色変更
    /// </summary>
    public void StartChangeColor()
    {
        //生成時にブロックの色をランダムにする
        int color = Random.Range(0, 3);
        blockData.blockColor = (ColorPallet)(color + 1);

        //現在のブロックの色を格納
        nowColor = blockData.blockColor;

        //色ごとに機能を変更
        ChangeBlockColorFunction();
    }

    /// <summary>
    /// ブロックの色ステータス毎に機能を変更する処理
    /// </summary>
    public void ItUpdate()
    {
        if (nowColor != blockData.blockColor)
            ChangeBlockColorFunction();
    }

    /// <summary>
    /// ブロックの色ごとに、BlockColorFunctionBaseをオーバーライドする
    /// </summary>
    private void ChangeBlockColorFunction()
    {
        switch (blockData.blockColor)
        {
            case ColorPallet.Red:
                if (blockColorFanctionBase as BlockColorFunctionRed == null)
                {
                    blockColorFanctionBase = null;
                    blockColorFanctionBase = new BlockColorFunctionRed(renderer, blockData);
                }
                break;

            case ColorPallet.Green:
                if (blockColorFanctionBase as BlockColorFunctionGreen == null)
                {
                    blockColorFanctionBase = null;
                    blockColorFanctionBase = new BlockColorFunctionGreen(renderer, blockData);
                }
                break;

            case ColorPallet.Blue:
                if (blockColorFanctionBase as BlockColorFunctionBlue == null)
                {
                    blockColorFanctionBase = null;
                    blockColorFanctionBase = new BlockColorFunctionBlue(renderer, blockData);
                }
                break;

            case ColorPallet.Yellow:
                if (blockColorFanctionBase as BlockColorFunctionYellow == null)
                {
                    blockColorFanctionBase = null;
                    blockColorFanctionBase = new BlockColorFunctionYellow(renderer, blockData);
                }
                break;

            case ColorPallet.Magenta:
                if (blockColorFanctionBase as BlockColorFunctionMagenta == null)
                {
                    blockColorFanctionBase = null;
                    blockColorFanctionBase = new BlockColorFunctionMagenta(renderer, blockData);
                }
                break;

            case ColorPallet.Cyan:
                if (blockColorFanctionBase as BlockColorFunctionCyan == null)
                {
                    blockColorFanctionBase = null;
                    blockColorFanctionBase = new BlockColorFunctionCyan(renderer, blockData);
                }
                break;

            default:
                blockColorFanctionBase = null;
                break;
        }

        if (blockColorFanctionBase != null) blockColorFanctionBase.ChangeBlockColor();
         nowColor = blockData.blockColor;
    }
}
