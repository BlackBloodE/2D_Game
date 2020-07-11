using UnityEngine;


public class CharacterController : MonoBehaviour
{
    ///
    ///<summary></summary>>
    ///
    #region 欄位
    public float hp;
    public float speed;
    public float jump;
    public bool dead;
    public int coins;
    public AudioClip jumpFX;
    public AudioClip slideFX;
    public AudioClip hitFX;

    public Animator ani;
    public CapsuleCollider2D CC;
    public Rigidbody2D rig;

    public bool isGround;
    #endregion

    #region 方法


    /// <summary>
    /// 角色跳躍功能:跳躍動畫、音效、往上跳
    /// </summary>
    
    private void Move()
    {
        if (rig.velocity.magnitude < 5)
        {
            rig.AddForce(new Vector2(speed, 0));
        }
        
    }
    
    private void Jump()
    {
        bool key = Input.GetKey(KeyCode.Space);

        ani.SetBool("Jump", !isGround);

        if (isGround)
        {
            if (key)
            {
                rig.AddForce(new Vector2(0, jump));
                isGround = false;
            }
        }
    }

    /// <summary>
    /// 角色滑行功能:滑行動畫、音效、縮小碰撞範圍
    /// </summary>
    private void Slide()
    {
        bool key = Input.GetKey(KeyCode.LeftControl);

        ani.SetBool("Slide", key);

        if (key)
        {
            CC.offset = new Vector2(0.2888068f, -1.288947f);
            CC.size = new Vector2(1.186361f, 1.9621f);
        }
        else
        {
            CC.offset = new Vector2(0.2888068f, -0.2353241f);
            CC.size = new Vector2(1.186361f, 4.069351f);
        }
        
    }

    /// <summary>
    /// 碰到障礙物、扣血
    /// </summary>
    private void Hit()
    {

    }

    /// <summary>
    /// 吃金幣:金幣數量++、音效、UI更新
    /// </summary>
    private void EatCoin()
    {

    }

    /// <summary>
    /// 死亡:死亡動畫、結束畫面
    /// </summary>
    private void Dead()
    {

    }
    #endregion

    #region 事件
    private void Start()
    {
        
    }
    private void Update()
    {
        Slide();
        
    }
    private void FixedUpdate()
    {
        Jump();
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGround = true;
        }
    }
    #endregion
}
