using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ԉ΂̋@�\
/// </summary>
public class FireworkData : MonoBehaviour
{
    //�ԉ΂̑ł��オ�鋭����ݒ�
    [SerializeField] private float forceMagnitude = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //�ł�����������Ƒ傫���ŉԉ΂̓��͂��v�Z
        Vector3 force = new Vector3(0, 1.0f, 0) * forceMagnitude;

        Rigidbody rigidbody = GetComponent<Rigidbody>();

        //�ԉ΂ɗ͂�������
        rigidbody.AddForce(force, ForceMode.Impulse);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

   /// <summary>
   /// �ԉ΂��u���b�N�ɐڐG����ƁA���ł���
   /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        //�u���b�N�̂ݐڐG���邱�ƂŁA�ԉ΂͏��ł���
        if (collision.transform.tag == "AliveBlock")
        {
            //�ԉ΂̏���
            Destroy(this.gameObject);
        }
    }
}
