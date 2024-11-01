using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Vector3 startPosition; // ���� ��ġ
    public float speed = 10; // �ӵ�
    public float leftPositionLimit = -85; // ���� �Ѱ�
    public float rightPositionLimit = 80; // ������ �Ѱ�

    void Start()
    {
        startPosition = gameObject.transform.position;
    }

    void Update()
    {
        // ������ �̵�
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // �Ѱ� ��ġ�� ������
        if (transform.position.x < leftPositionLimit || transform.position.x > rightPositionLimit)
        {
            // ���� ��ġ�� �̵�
            gameObject.transform.position = startPosition;
        }
    }
}
