using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] Texture2D[] mouseCursorImage; 
    void Start()
    {
        OnDefaultCursorMode();
    }

    void Update()
    {
    }

    // ����Ʈ Ŀ��
    public void OnDefaultCursorMode()
    {
        Cursor.SetCursor(mouseCursorImage[0], Vector2.zero, CursorMode.Auto);
    }

    // �̵� Ŀ��
    public void OnMoveCursorMode()
    {
        Cursor.SetCursor(mouseCursorImage[2], Vector2.zero, CursorMode.Auto);
    }

    // �Ǽ� Ŀ��
    public void OnBuildCursorMode()
    {
        Cursor.SetCursor(mouseCursorImage[1], Vector2.zero, CursorMode.Auto);
    }

    // �ε� Ŀ��
    public void OnLoadingCursorMode()
    {
        Cursor.SetCursor(mouseCursorImage[2], Vector2.zero, CursorMode.Auto);
    }
}
