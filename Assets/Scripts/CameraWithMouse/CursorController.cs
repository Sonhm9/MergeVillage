using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] Texture2D[] mouseCursorImage;
    
    public enum ModeState
    {
        Default,
        Move,
        Build,
        Loading
    }
    public ModeState modeState;

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
        modeState = ModeState.Default;
        Cursor.SetCursor(mouseCursorImage[0], Vector2.zero, CursorMode.Auto);
    }

    // �̵� Ŀ��
    public void OnMoveCursorMode()
    {
        modeState = ModeState.Move;
        Cursor.SetCursor(mouseCursorImage[1], Vector2.zero, CursorMode.Auto);
    }

    // �Ǽ� Ŀ��
    public void OnBuildCursorMode()
    {
        modeState = ModeState.Build;
        Cursor.SetCursor(mouseCursorImage[2], Vector2.zero, CursorMode.Auto);
    }

    // �ε� Ŀ��
    public void OnLoadingCursorMode()
    {
        modeState = ModeState.Loading;
        Cursor.SetCursor(mouseCursorImage[3], Vector2.zero, CursorMode.Auto);
    }
}
