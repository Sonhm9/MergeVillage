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

    // 디폴트 커서
    public void OnDefaultCursorMode()
    {
        Cursor.SetCursor(mouseCursorImage[0], Vector2.zero, CursorMode.Auto);
    }

    // 이동 커서
    public void OnMoveCursorMode()
    {
        Cursor.SetCursor(mouseCursorImage[2], Vector2.zero, CursorMode.Auto);
    }

    // 건설 커서
    public void OnBuildCursorMode()
    {
        Cursor.SetCursor(mouseCursorImage[1], Vector2.zero, CursorMode.Auto);
    }

    // 로딩 커서
    public void OnLoadingCursorMode()
    {
        Cursor.SetCursor(mouseCursorImage[2], Vector2.zero, CursorMode.Auto);
    }
}
