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
        Vector3 direction = new Vector3(moveX, 0, moveZ);
        Vector3 force = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (direction.magnitude<0.1f)
        {
            //Debug.Log(Input.GetAxis("Horizontal"));
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }
        //if (moveX != 0f || moveZ != 0f)
        //{
            transform.LookAt(transform.position + direction);
            
            rb.velocity = direction;
        //}
        //else
        //{
        //    animator.SetBool("Run", false);
        //    rb.velocity = direction;
        //}
    }
}
