using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveVector * moveSpeed;
    }

    public void SetVector(Vector3 moveVec, Vector3 position)
    {
        moveVector = moveVec;
        transform.position = position;
    }
}
