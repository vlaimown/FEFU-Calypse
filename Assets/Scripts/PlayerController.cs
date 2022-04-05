using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D hero;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;

    [SerializeField] private Vector2 direction;

    private bool facingRight = true;

    private void Start()
    {
        hero = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        direction = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        hero.MovePosition(hero.position + direction * speed * Time.deltaTime);

        if(facingRight == true && direction.x < 0)
        {
            Flip();
        }

        else if (facingRight == false && direction.x > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;

        transform.localScale = scaler;
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float health;
    //public Animator animator;
    private Vector2 direction;
    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool IsAttack = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (!IsAttack)
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");

            //Debug.Log("Attack");
            //animator.SetFloat("Horizontal", direction.x);
            //animator.SetFloat("Vertical", direction.y);
            //animator.SetFloat("Speed", direction.sqrMagnitude);
            //Debug.Log("Attack");
            if (Input.GetMouseButton(0))
            {

                //animator.SetTrigger("attack");
                IsAttack = true;
            }
            
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        if (!facingRight && direction.x > 0)
        {
            Flip();
        }
        else if (facingRight && direction.x < 0)
        {
            Flip();
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void AttackOver()
    {
        IsAttack = false;

    }
}*/
