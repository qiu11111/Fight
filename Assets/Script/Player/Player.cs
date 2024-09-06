using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public enum PlayerStateType
{
    Idle,Walk,Jump,Air,Hurt,Attack
}

public class Player : Character
{
    private Dictionary<PlayerStateType, IState> states;
    private IState currentState;

    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public Animator anim;

    public PlayerInput playerInput;

    public Vector2 faceDir;

    [Header("待机状态")]
    public bool isIdle;

    [Header("移动状态")]
    public bool isWalk;
    public float speed;
    public Vector2 direction;

    [Header("起跳")]
    public bool isJump;
    public float jumpForce;

    [Header("下落")]
    public bool isAir;

    [Header("碰撞检测")]
    public Transform groundCheckPosition;
    public float groundCheckDistance;
    public LayerMask whatIsGround;

    [Header("受伤")]
    public bool isHurt;
    public float backV;
    public float backTIme;

    [Header("攻击")]
    public bool isAttack;
    //private Weapon1 weapon;
    public bool isAttackPush;
    private Battle battle;
    public bool isAttackCool;



    [Header("数据区")]
    public int bowDamage;
    public int staffDamage;
    public int swordDamage;
    public int baseDamage;

    public RuntimeAnimatorController animController;
    public GameObject mainBone;
    public bool isRotate;
    public bool IsRotate
    {
        get => isRotate;
        set
        {
            if (value != isRotate)
            {
                mainBone.transform.Rotate(180, 0, 0);
                isRotate = value;
            }
        }
    }


    private void Awake()
    {
        states = new Dictionary<PlayerStateType, IState>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mainBone = GameObject.Find("bone_1");

        //weapon = transform.Find("Weapon").GetComponent<Weapon1>();
        battle = transform.Find("Battle").GetComponent<Battle>();

        states.Add(PlayerStateType.Idle, new PlayerIdleState(this));
        states.Add(PlayerStateType.Walk, new PlayerWalkState(this));
        states.Add(PlayerStateType.Jump, new PlayerJumpState(this));
        states.Add(PlayerStateType.Air, new PlayerAirState(this));
        states.Add(PlayerStateType.Hurt, new PlayerHurtState(this));
        states.Add(PlayerStateType.Attack, new PlayerAttackState(this,battle));

        SwitchToState(PlayerStateType.Idle);
        playerInput.turnOnPlayer();
        faceDir = Vector2.right;
    }

    private void OnEnable()
    {
        playerInput.onWalk += onWalk;
        playerInput.disWalk += disWalk;
        playerInput.onJump += onJump;
        playerInput.onAttack += onAttack;
        playerInput.disAttack += disAttack;
    }
    private void OnDisable()
    {
        playerInput.onWalk -= onWalk;
        playerInput.disWalk -= disWalk;
        playerInput.onJump -= onJump;
        playerInput.onAttack -= onAttack;
        playerInput.disAttack -= disAttack;
    }
    //攻击回调
    public void onAttack()
    {
        if (!isAttackCool)
        {
            isAttack = true;
            isAttackPush = true;
        }
        
    }
    public void disAttack()
    {
        isAttackPush = false;
    }
    //跳跃回调
    public void onJump()
    {
        isJump = true;
    }
    //移动结束回调
    public void disWalk()
    {
        isWalk = false;
        direction = Vector2.zero;
    }

    //移动回调
    public void onWalk(Vector2 direction)
    {
        isWalk = true;
        this.direction = direction;
    }
    //切换状态
    public void SwitchToState(PlayerStateType state)
    {
        if (currentState != null)
            currentState.onExit();
        currentState = states[state];
        currentState.onEnter();
    }
    private void Update()
    {
        currentState.onUpdate();
        if (Input.GetKeyDown(KeyCode.H))
        {
            SkillManager.instance.zhSkill.canBeUsed();
        }
        setFace();
        //setRotate();
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            mainBone.transform.rotation = Quaternion.Euler(0, 180, 89.816f);
            print("success");
        }*/
        if (isHurt)
            SwitchToState(PlayerStateType.Hurt);
        if (Input.GetKeyDown(KeyCode.P))
            mainBone.transform.Rotate(180, 0, 0);


    }
    public void setFace()
    {
        if (isRotate)
            faceDir = new Vector2(-1, 0);
        if (!isRotate)
            faceDir = new Vector2(1, 0);
    }
 /*   public void setRotate()
    {
        if (faceDir.x == -1)
        {
            sr.flipX = true;
            //mainBone.transform.rotation = Quaternion.Euler(0, 180, 89.816f);
            //transform.rotation= Quaternion.Euler(0, 180, 0);

        }

        if (faceDir.x == 1)
        {
            sr.flipX = false;
           // mainBone.transform.rotation = Quaternion.Euler(0, 0, 89.816f);
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            //transform.rotation= Quaternion.Euler(0, 0, 0);
        }
            

    }*/
    public void setRotate()
    {
        if (faceDir.x == -1)
        {
            mainBone.transform.rotation = Quaternion.Euler(0, 180, 89.816f);
        }
        if (faceDir.x == 1)
        {
            mainBone.transform.rotation = Quaternion.Euler(0, 0, 89.816f);
        }
    }
    private void FixedUpdate()
    {
        currentState.onFixedUpdate();
    }
    //玩家移动方法
    public void move()
    {
        if (direction.magnitude > 0.01f)
        {
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
            if (direction.x > 0)
            {
                IsRotate= false;

            }

            if (direction.x < 0)
            {
                IsRotate = true;
            }

        }
    }
    //地面碰撞检测
    public bool groundCheck()
    {
        return Physics2D.Raycast(groundCheckPosition.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheckPosition.position, groundCheckPosition.position + Vector3.down * groundCheckDistance);
    }

    //受伤回调
    public void getHurt()
    {
        isHurt = true;
    }

    public float getStats(string statsName)
    {
        if (statsName == "damage")
        {
            return damage;
        }
        else if (statsName == "maxBlood")
        {
            return maxBlood;
        }
        else if (statsName == "currentBlood")
        {
            return currentBlood;
        }
        else if (statsName == "jumpForce")
        {
            return jumpForce;
        }
        else if (statsName == "baseDamage")
            return baseDamage;
        else if (statsName == "bowDamage")
            return bowDamage;
        else if (statsName == "staffDamage")
            return staffDamage;
        else if (statsName == "swordDamage")
            return swordDamage;
        else
        {
            return 0;
        }
    }

    public void setMove(Vector2 v)
    {
        if (faceDir.x > 0)
        {
            rb.velocity = v;
        }
        else
        {
            rb.velocity = new Vector2(-v.x, v.y);
        }
        
    }
    public void stop()
    {
        rb.velocity = Vector2.zero;
    }

    //开启攻击冷却
    public IEnumerator startAttackCool(float time)
    {
        isAttackCool = true;
        yield return new WaitForSeconds(time);
        isAttackCool = false;
    }
    public void startAttackCool1(float x)
    {
        StartCoroutine(startAttackCool(x));
    }
    public int getDamage(Weapons weapon)
    {
        if (weapon == Weapons.Bow)
        {
            return baseDamage + bowDamage;
        }
        if (weapon == Weapons.Staff)
        {
            return baseDamage + staffDamage;
        }
        if (weapon == Weapons.Sword)
        {
            return baseDamage + swordDamage;
        }
        if (weapon == Weapons.NoWeapon)
        {
            return baseDamage;
        }
        else
        {
            return 0;
        }
    }



}
