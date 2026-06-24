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

    float moveDirection = 0.0f;

    /// <summary>
    /// 게임이 실행될 때 한 번 호출되는 함수.
    /// </summary>
    void Start()
    {
        // Debug.Log : 콘솔창에 메시지를 출력해주는 유니티 제공 함수.
        //Debug.Log("이것은 나의 게임 프로그래밍이다!!!");
        //Debug.Log("플레이어 이름: " + playerName);

        Debug.Log("result = " + AddNumbers(3, 4));
        PrintMessage("반갑습니다!!!!");
        PrintMessage("안녕히 가세요!!!");
    }

    /// <summary>
    /// 게임이 실행되는 동안 매 프레임마다 호출되는 함수.
    /// </summary>
    void Update()
    {
        CheckInput();

        if (canMove == true)
        {
            Move();
        }
        else
        {
            //Debug.Log("이동할 수 없다");
        }

        if(Input.GetKeyDown(KeyCode.P) == true)
        {
            //Debug.Log("현재 위치: " + transform.position);
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

        if(Input.GetKey(KeyCode.Space) == true)
        {
            //Debug.Log("스페이크 키 입력 확인!!!!!");
        }
    }

    void Move()
    {
        // 좌우 이동 방향을 만드는 코드.
        Vector3 move = new Vector3(moveDirection, 0.0f, 0.0f);
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    int AddNumbers(int number1, int number2)
    {
        int result = number1 + number2;
        
        return result;
    }

    void PrintMessage(string message)
    {
        Debug.Log(message);
    }
}
