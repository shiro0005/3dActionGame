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
        //�ړ���
        Vector3 direction = new Vector3(moveX, 0, moveZ);

        if (direction.magnitude < 0.1f)
        {
            animator.SetBool("Run", false);//�A�j���[�V�����؂�ւ�
        }
        else
        {
            animator.SetBool("Run", true);
        }

        transform.LookAt(transform.position + direction);//�L�����N�^�[��������

        rb.velocity = direction;//�L�����N�^�[�ړ�

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
