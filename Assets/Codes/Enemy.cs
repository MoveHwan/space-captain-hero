using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;
    Vector2 nextVec;
    Animator anim;

    bool isLive;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLive)
            return;

        Vector2 dirVec = target.position - rigid.position;
        nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        if (isLive)
            return;
        
        anim.SetFloat("MoveX", nextVec.x);
        anim.SetFloat("MoveY", nextVec.y);
        spriter.flipX = target.position.x < rigid.position.x;
    }
}
