using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwordScript : MonoBehaviour
{
    public Animator Animator { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public BoxCollider2D SwordCollider { get; private set; }
    public BoxCollider2D HitBoxCollider { get; private set; }
    
    public GameObject InteractButton;

    public UnityEvent TakeSword,ThrowSword;

    private bool isSpinning;
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        HitBoxCollider = GetComponentInChildren<BoxCollider2D>();
        SwordCollider = GetComponent<BoxCollider2D>();
        Animator = GetComponent<Animator>();

        Animator.SetBool("idleState", true);
    }

    private void Update()
    {
        if(isSpinning)
        {
            InteractButton.SetActive(false);
            ColliderHitCheck();
        }
    }

    public void TakeItem()
    {
        TakeSword?.Invoke();
    }

    public void ThrowItem()
    {
        isSpinning = true;
        transform.SetParent(null);
        ThrowSword?.Invoke();
        SetVelocity();

        Animator.SetBool("idleState", false);
        Animator.SetBool("spinState", true);
        Animator.SetBool("embeddedState", false);
    }

    public void EmbeddedSword()
    {

    }

    private void SetVelocity()
    {
        RB.velocity = new Vector2(PlayerScript.FacingDirection * 10, 0);
    }

    public void ColliderHitCheck()
    {
        Collider2D[] enemyList = Physics2D.OverlapCircleAll(transform.position, 2f);

        foreach (Collider2D enemy in enemyList)
        {
            if(enemy.GetComponent<IDamagable>() != null)
            {
                Debug.Log("You hit!");
            }
        }
    }

    #region Unity OnTrigger Functions

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InteractButton.SetActive(true);
        }
        else if (collision.tag != "Player" || collision == null)
        {
            InteractButton.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision == null)
        {
            InteractButton.SetActive(false);
        }
    }

    #endregion
}
