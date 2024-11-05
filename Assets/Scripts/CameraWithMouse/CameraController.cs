using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour
{
    // ī�޶� �̵� ����
    float mouseSensitive = 2;
    Vector3 targetPosition;
    Vector3 velocity = Vector3.zero;

    // ī�޶� ���� ����
    float minX = -80;
    float maxX = 80;
    float minY = -5;
    float maxY = 120;

    // ī�޶� �� ����
    float targetZoom;
    float lerfTime = 0.2f;
    float zoomSpeed = 10;

    CursorController cursorController;
    static CameraController instance;

    public bool isCameraPaused = false;
    public static CameraController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CameraController();
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cursorController = GetComponent<CursorController>();
        targetPosition = gameObject.transform.position;
        targetZoom = Camera.main.orthographicSize;
    }

    void Update()
    {
        if (isCameraPaused == true)
        {
            return;
        }
        // ī�޶� �̵�
        if (Input.GetMouseButton(1))
        {
            cursorController.OnMoveCursorMode(); // Ŀ�� "�̵����"
            targetPosition += new Vector3(-Input.GetAxis("Mouse X") / mouseSensitive, -Input.GetAxis("Mouse Y") / mouseSensitive, 0); // ���콺 Input�� ���� Ÿ�� ������ ����

            ClampCameraPosition(); // �̵� ���� ����
        }
        
        if (Input.GetMouseButtonUp(1))
        {
            cursorController.OnDefaultCursorMode(); // Ŀ�� "�⺻���"
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, lerfTime); // �ε巴�� �̵�

        // ī�޶� �� �� �ƿ�
        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            targetZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed; // �� ��
            targetZoom = Mathf.Clamp(targetZoom, 25, 45); // �ִ� �� ���� ����

            ClampCameraPosition(); // �̵� ���� ����
        }
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed); // �ε巴�� �� �� �ƿ�
    }

    // ī�޶� ���� ���� �޼���
    void ClampCameraPosition()
    {
        float camHeight = Camera.main.orthographicSize; // ī�޶� ����
        float camWidth = camHeight * Camera.main.aspect; // ī�޶� ����

        targetPosition.x = Mathf.Clamp(targetPosition.x, minX + camWidth, maxX - camWidth); // ���� �̵� ����
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY + camHeight, maxY - camHeight); // ���� �̵� ����
    }
}
