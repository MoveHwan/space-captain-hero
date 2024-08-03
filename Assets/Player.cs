using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    int direction = 1;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    public Animator buffAnim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + nextVec); //위치 이동


    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);


        if (inputVec.x > 0) { direction = 0; spriter.flipX = true; }
        if (inputVec.x < 0) { direction = 0; spriter.flipX = false; }
        if (inputVec.y > 0) { direction = 2; }
        if (inputVec.y < 0) { direction = 1; }


        anim.SetFloat("xDir", inputVec.x);
        anim.SetFloat("yDir", inputVec.y);

        anim.SetFloat("Direction", direction);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals("buff")){ 
            speed+=0.5f;
            anim = buffAnim;
            anim.SetBool("Buff", true);
        }
        
    }

}
