using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public enum EnemyStateType
{
    Idle,Patrol,Chase,Hurt,Attack,Dead
}

public class Enemy : Character
{
    public Dictionary<EnemyStateType, IState> states;
    public IState currenState;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator anim;

    [Header("´ý»ú")]
    public bool isIdle;
    public float idleTime;

    [Header("Ñ²Âß")]
    public bool isPatrol;
    public float speed;
    public Vector2 faceDir;
    public Vector2 direction;

    [Header("Åö×²¼ì²â")]
    public Transform groundCheckPosition;
    public float groundCheckDistance;
    public LayerMask whatIsGround;

    [Header("ÊÜÉË")]
    public bool isHurt;
    public float attackBackV;
    public float backTime;

    [Header("×·»÷")]
    public bool isChase;
    public float chaseDistance;
    public Transform player;
    public LayerMask whatIsPlayer;

    [Header("¹¥»÷")]
    public bool isAttack;
    public float attackDistance;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        states = new Dictionary<EnemyStateType, IState>();

        states.Add(EnemyStateType.Idle, new EnemyIdleState(this));
        states.Add(EnemyStateType.Patrol, new EnemyPatrolState(this));
        states.Add(EnemyStateType.Chase, new EnemyChaseState(this));
        states.Add(EnemyStateType.Hurt, new EnemyHurtState(this));
        states.Add(EnemyStateType.Attack, new EnemyAttackState(this));
        states.Add(EnemyStateType.Dead, new EnemyDeadState(this));

        switchTo(EnemyStateType.Idle);
    }

    protected override void Start()
    {
        base.Start();
        faceDir = new Vector2(-1, 0);
        direction = new Vector2(-1, 0);
    }

    /*private void Start()
    {
        faceDir = new Vector2(-1, 0);
        direction = new Vector2(-1, 0);
    }*/

    public void switchTo(EnemyStateType state)
    {
        if (currenState != null)
            currenState.onExit();
        currenState = states[state];
        currenState.onEnter();
    }
    private void Update()
    {
        currenState.onUpdate();
        updateFace();
        direction = faceDir;
        getPlayer();
        if (Input.GetKeyDown(KeyCode.B))
            isHurt = true;
        if (transform.position.y < -50.0f)
            Destroy(gameObject);

    }
    private void FixedUpdate()
    {
        currenState.onFixedUpdate();
    }
    public void move()
    {
        if (direction.magnitude > 0.01f)
        {
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
            if (direction.x > 0)
                sr.flipX = true;
            if (direction.x < 0)
                sr.flipX = false;
        }
    }

    public void updateFace()
    {
        if (sr.flipX)
            faceDir = new Vector2(1, 0);
        if (!sr.flipX)
            faceDir = new Vector2(-1, 0);
    }

    //Ç½±ÚÅö×²¼ì²â
    public bool groundCheck()
    {
        return Physics2D.Raycast(groundCheckPosition.position, faceDir, groundCheckDistance, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(groundCheckDistance * -1, 0, 0));
    }
    //»ñµÃÍæ¼ÒÎ»ÖÃ
    public void getPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, chaseDistance, whatIsPlayer);
        if (colliders.Length > 0)
        {
            player = colliders[0].transform;
        }
        else
        {
            player = null;
        }
    }
    //ÊÜÉË»Øµ÷
    public void getHurt()
    {
        isHurt = true;
    }
    //ËÀÍö»Øµ÷
    public virtual void getdie()
    {
        Destroy(gameObject);
    }

    //¹¥»÷Ö¡ÊÂ¼þ
    public void attackEvent()
    {
        if (player != null)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackDistance, whatIsPlayer);
            colliders[0].GetComponent<Player>().takeDamage(damage);
        }
    }
    public void grade(float n)
    {
        maxBlood *= n;
    }
}
