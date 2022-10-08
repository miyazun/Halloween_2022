using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField]
    private GroundCheaker ground;
    private Animator anim;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        var moveCheack = Observable.EveryUpdate()
                         .Subscribe(_ => MoveAnim());
    }

    private void MoveAnim()
    {
        Debug.Log(rb.velocity.magnitude);
        if (rb.velocity.magnitude > 1.0f)
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }

        if (ground.isGround)
        {
            anim.SetBool("jump", false);
        }
        else
        {
            anim.SetBool("jump", true);
        }
    }

    private void JumpAnim()
    {
        anim.SetBool("jump", true);
    }

    private void StandAnim()
    {
        anim.SetBool("run", false);
        anim.SetBool("jump", false);
    }

}
