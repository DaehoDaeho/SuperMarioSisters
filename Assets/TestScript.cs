using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("이것이 나의 첫 게임 프로그래밍이다!!!!");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) == true)
        {
            transform.position += Vector3.right * 3.0f * Time.deltaTime;
        }
    }
}
