using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Vector3 startPosition; // 시작 위치
    public float speed = 10; // 속도
    public float leftPositionLimit = -85; // 왼쪽 한계
    public float rightPositionLimit = 80; // 오른쪽 한계

    void Start()
    {
        startPosition = gameObject.transform.position;
    }

    void Update()
    {
        // 앞으로 이동
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // 한계 위치를 넘으면
        if (transform.position.x < leftPositionLimit || transform.position.x > rightPositionLimit)
        {
            // 시작 위치로 이동
            gameObject.transform.position = startPosition;
        }
    }
}
