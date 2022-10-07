using UnityEngine;
using UniRx;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    private float playerSize;

    void Start()
    {
        playerSize = 0.2f;
        rb = GetComponent<Rigidbody2D>();
        var move = Observable.EveryUpdate()
                   .Subscribe(_ => XMove());
    }

    private void XMove()
    {
        float xForth = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xForth * speed, rb.velocity.y);
        //Debug.Log(rb.velocity);

        if (xForth != 0.0f)
        {
            transform.localScale = new Vector2(xForth * playerSize, playerSize);
        }
    }
}
