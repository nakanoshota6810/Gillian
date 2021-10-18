using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 花火の機能
/// </summary>
public class FireworkData : MonoBehaviour
{
    //花火の打ち上がる強さを設定
    [SerializeField] private float forceMagnitude = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //打ちあがる向きと大きさで花火の動力を計算
        Vector3 force = new Vector3(0, 1.0f, 0) * forceMagnitude;

        Rigidbody rigidbody = GetComponent<Rigidbody>();

        //花火に力を加える
        rigidbody.AddForce(force, ForceMode.Impulse);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

   /// <summary>
   /// 花火がブロックに接触すると、消滅する
   /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        //ブロックのみ接触することで、花火は消滅する
        if (collision.transform.tag == "AliveBlock")
        {
            //花火の消滅
            Destroy(this.gameObject);
        }
    }
}
