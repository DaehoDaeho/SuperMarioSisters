using UnityEngine;

/// <summary>
/// 플레이어 캐릭터 조작을 담당하는 스크립트.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4.0f;
    float moveDirection = 0.0f;

    /// <summary>
    /// 게임이 실행될 때 한 번 호출되는 함수.
    /// </summary>
    void Start()
    {
        Debug.Log("이것은 나의 게임 프로그래밍이다!!!");
    }

    /// <summary>
    /// 게임이 실행되는 동안 매 프레임마다 호출되는 함수.
    /// </summary>
    void Update()
    {
        CheckInput();
        Move();
    }

    void CheckInput()
    {
        moveDirection = 0.0f;

        // 오른쪽 방향키를 누르고 있는지 체크.
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            moveDirection = 1.0f;
        }

        // 왼쪽 방향키를 누르고 있는지 체크.
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            moveDirection = -1.0f;
        }

        // A 키를 누르고 있는지 체크.
        if (Input.GetKey(KeyCode.A) == true)
        {
            moveDirection = -1.0f;
        }

        // D 키를 누르고 있는지 체크.
        if (Input.GetKey(KeyCode.D) == true)
        {
            moveDirection = 1.0f;
        }
    }

    void Move()
    {
        // 좌우 이동 방향을 만드는 코드.
        Vector3 move = new Vector3(moveDirection, 0.0f, 0.0f);
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}
