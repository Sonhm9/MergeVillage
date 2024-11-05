using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour
{
    // 카메라 이동 변수
    float mouseSensitive = 2;
    Vector3 targetPosition;
    Vector3 velocity = Vector3.zero;

    // 카메라 범위 제한
    float minX = -80;
    float maxX = 80;
    float minY = -5;
    float maxY = 120;

    // 카메라 줌 변수
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
        // 카메라 이동
        if (Input.GetMouseButton(1))
        {
            cursorController.OnMoveCursorMode(); // 커서 "이동모드"
            targetPosition += new Vector3(-Input.GetAxis("Mouse X") / mouseSensitive, -Input.GetAxis("Mouse Y") / mouseSensitive, 0); // 마우스 Input에 따른 타겟 포지션 변경

            ClampCameraPosition(); // 이동 범위 제한
        }
        
        if (Input.GetMouseButtonUp(1))
        {
            cursorController.OnDefaultCursorMode(); // 커서 "기본모드"
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, lerfTime); // 부드럽게 이동

        // 카메라 줌 인 아웃
        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            targetZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed; // 줌 인
            targetZoom = Mathf.Clamp(targetZoom, 25, 45); // 최대 줌 범위 제한

            ClampCameraPosition(); // 이동 범위 제한
        }
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed); // 부드럽게 줌 인 아웃
    }

    // 카메라 범위 제한 메서드
    void ClampCameraPosition()
    {
        float camHeight = Camera.main.orthographicSize; // 카메라 세로
        float camWidth = camHeight * Camera.main.aspect; // 카메라 가로

        targetPosition.x = Mathf.Clamp(targetPosition.x, minX + camWidth, maxX - camWidth); // 가로 이동 제한
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY + camHeight, maxY - camHeight); // 세로 이동 제한
    }
}
