using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        var move = Observable.EveryUpdate()
                   .Subscribe(_ => XMove());
    }


    private void XMove()
    {
        float xForth = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xForth * speed, rb.velocity.y);
        Debug.Log(rb.velocity);
    }
}
