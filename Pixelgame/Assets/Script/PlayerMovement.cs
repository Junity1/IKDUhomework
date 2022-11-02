using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D myBody;
    [SerializeField] private int speed = 5;
    private Animator myAnimator;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        if (movement.x != 0 || movement.y != 0)
        {
            myAnimator.SetFloat("x", movement.x);
            myAnimator.SetFloat("y", movement.y);

            myAnimator.SetBool("isWalking", true);

        }
        else
        {
            myAnimator.SetBool("isWalking", false);
        }
    }

    private void FixedUpdate()
    {
        myBody.velocity = movement * speed;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}