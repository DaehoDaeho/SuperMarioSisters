using UnityEngine;

/// <summary>
/// 플레이어 캐릭터 조작을 담당하는 스크립트.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public string playerName = "Hero";
    public int playerHp = 10;
    public bool canMove = true;
    public float moveSpeed = 3.0f;

    public float jumpPower = 7.0f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    float moveDirection = 0.0f;

    Rigidbody2D playerBody;
    Collider2D playerCollider;
    SpriteRenderer spriteRenderer;

    bool isGrounded;    // 플레이어가 현재 바닥에 닿아 있는가를 저장하는 변수.

    /// <summary>
    /// 게임이 실행될 때 한 번 호출되는 함수.
    /// </summary>
    void Start()
    {
        // GetComponent는 게임 오브젝트에 붙어 있는 컴포넌트를 가져오기 위한 함수.
        playerBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// 게임이 실행되는 동안 매 프레임마다 호출되는 함수.
    /// </summary>
    void Update()
    {
        CheckGround();
        CheckInput();

        Jump();

        if (canMove == true)
        {
            Move();
        }
        else
        {
            //Debug.Log("이동할 수 없다");
        }
    }

    void CheckInput()
    {
        moveDirection = 0.0f;

        // 오른쪽 방향키를 누르고 있는지 체크.
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            //Debug.Log("오른쪽 키를 누르고 있다.");
            moveDirection = 1.0f;
        }

        // 왼쪽 방향키를 누르고 있는지 체크.
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            //Debug.Log("왼쪽 키를 누르고 있다.");
            moveDirection = -1.0f;
        }

        // A 키를 누르고 있는지 체크.
        if (Input.GetKey(KeyCode.A) == true)
        {
            //Debug.Log("왼쪽 키를 누르고 있다.");
            moveDirection = -1.0f;
        }

        // D 키를 누르고 있는지 체크.
        if (Input.GetKey(KeyCode.D) == true)
        {
            //Debug.Log("오른쪽 키를 누르고 있다.");
            moveDirection = 1.0f;
        }
    }

    void Move()
    {
        // 좌우 이동 방향을 만드는 코드.
        //Vector3 move = new Vector3(moveDirection, 0.0f, 0.0f);
        //transform.position += move * moveSpeed * Time.deltaTime;

        // playerBody.linearVelocity
        // 오브젝트가 현재 어느 방향으로 얼마나 빠르게 움직이는지를 나타내는 속도값.
        playerBody.linearVelocity = new Vector2(moveDirection * moveSpeed, playerBody.linearVelocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            if (isGrounded == true)
            {
                Vector2 velocity = playerBody.linearVelocity;
                velocity.y = jumpPower;
                playerBody.linearVelocity = velocity;

                isGrounded = false;
            }
        }
    }

    void CheckGround()
    {
        // Physics2D.OverlapCircle : 충돌 체크를 위해 가상의 원을 그려주는 함수.
        Collider2D ground = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // null : 아무것도 아닌 데이터.
        if(ground != null)  // 플레이어의 발 아래에 바닥이 있다면.
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
