using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlScript : MonoBehaviour
{
    public GameObject AliveGO { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Animator Animator { get; private set; }
    public EnemyScript enemyScript;
    private void Start()
    {
        enemyScript = GameObject.Find("Seashell").GetComponent<Seashell_EntityScript>();
        AliveGO = transform.Find("AliveGO").gameObject;
        RB = AliveGO.GetComponent<Rigidbody2D>();
        Animator = AliveGO.GetComponent<Animator>();
        
        IdleState();
    }
    private void Update()
    {

    }
    private void IdleState() 
    {
        Animator.SetBool("idleState", true);
        Animator.SetBool("deadState", false);
        RB.velocity = new Vector2(enemyScript.FacingDirection * 10, 0);
    }
    public void DeadState()
    {
        Animator.SetBool("idleState", false);
        Animator.SetBool("deadState", true);
        RB.velocity = new Vector2(0, 0);
    }

}
