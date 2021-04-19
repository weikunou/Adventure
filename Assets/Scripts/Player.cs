using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家类
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// 移动速度
    /// </summary>
    public float speed;

    /// <summary>
    /// 跳跃力
    /// </summary>
    public float jumpForce;

    /// <summary>
    /// 是否在地面上
    /// </summary>
    public bool isGround;

    /// <summary>
    /// 是否能跳跃
    /// </summary>
    public bool canJump;

    /// <summary>
    /// 地面检测
    /// </summary>
    public Transform groundCheck;

    /// <summary>
    /// 检测范围
    /// </summary>
    public float checkRadius;

    /// <summary>
    /// 检测图层
    /// </summary>
    public LayerMask groundLayer;

    /// <summary>
    /// 金币数
    /// </summary>
    public int coin;

    public DynamicJoystick joystick;

    /// <summary>
    /// 刚体
    /// </summary>
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        PlayerMove();
        PlayerJump();
        PhysicsCheck();
    }

    void Update()
    {
        // 按下跳跃键并且在地面上
        if(Input.GetButtonDown("Jump") && isGround)
        {
            canJump = true;
        }
    }

    /// <summary>
    /// 角色移动
    /// </summary>
    void PlayerMove()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");
        float horizontal = joystick.Horizontal;

        // 左右移动
        if (horizontal != 0)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            transform.localScale = new Vector2(horizontal, 1);
        }
        // 静止
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // 空中下落
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = 3;
        }
    }

    /// <summary>
    /// 玩家跳跃
    /// </summary>
    void PlayerJump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.gravityScale = 3;
            canJump = false;
        }
    }

    /// <summary>
    /// 跳跃按钮
    /// </summary>
    public void JumpButton()
    {
        if (isGround)
        {
            canJump = true;
        }
    }

    /// <summary>
    /// 地面检测
    /// </summary>
    void PhysicsCheck()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (isGround && rb.velocity.y <= 0 && rb.gravityScale != 1)
        {
            rb.gravityScale = 1;
        }
    }

    // 检测绘图
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Coin"))
        {
            coin++;
            UIManager.instance.UpdateCoinText(coin);
            Destroy(collision.gameObject);
        }

        if (collision.name.Contains("Trap"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            GameManager.instance.GameOver();
        }
    }
}
