using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{

    Rigidbody2D rigidbody2d;
    [SerializeField] float speed = 2f;
    Vector2 motionVector;
    Animator animator;
    public Vector2 lastMotionVector;
    public bool moving;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Debug.Log("MOVING? " + moving);
        motionVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);

        Debug.Log(lastMotionVector);
        if (horizontal != 0 || vertical != 0)
        {
            if (horizontal != 0)
            {
                Debug.Log("Horizontal");
            }
            else if (vertical != 0)
            {
                Debug.Log("Vertical");
            }
            lastMotionVector = new Vector2(horizontal, vertical).normalized;
            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }
        else
        {
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rigidbody2d.velocity = motionVector * speed;
        // Log detailed direction information
        if (motionVector.x > 0)
            Debug.Log("Moving Right");
        else if (motionVector.x < 0)
            Debug.Log("Moving Left");

        if (motionVector.y > 0)
            Debug.Log("Moving Up");
        else if (motionVector.y < 0)
            Debug.Log("Moving Down");

        // Log speed
        Debug.Log($"Speed: {speed}");
    }
}
