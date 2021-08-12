using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Player_Speed;
    float moveX = 0f;
    float moveZ = 0f;
    Rigidbody rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * Player_Speed;
        moveZ = Input.GetAxis("Vertical") * Player_Speed;
        //移動量
        Vector3 direction = new Vector3(moveX, 0, moveZ);

        if (direction.magnitude < 0.1f)
        {
            animator.SetBool("Run", false);//アニメーション切り替え
        }
        else
        {
            animator.SetBool("Run", true);
        }

        transform.LookAt(transform.position + direction);//キャラクター向き調整

        rb.velocity = direction;//キャラクター移動

        if (Input.GetButtonDown("Fire3"))
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }

    }
}
