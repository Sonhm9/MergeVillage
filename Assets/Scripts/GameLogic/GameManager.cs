using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform[] positions;
    static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }

    public int point = 0;
    void Start()
    {
        StartGame();
    }

    void Update()
    {
        
    }
    public void CheckOver()
    {
        int count = 0;
        foreach(Transform transform in positions)
        {
            if (transform.childCount > 0)
            {
                count++;
            }
        }
        if (count >= positions.Length)
        {
            StartCoroutine(ReCheckOver());
        }
    }
    IEnumerator ReCheckOver()
    {
        yield return new WaitForSeconds(2f);
        int count = 0;
        foreach (Transform transform in positions)
        {
            if (transform.childCount > 0)
            {
                count++;
            }
        }
        if (count >= positions.Length)
        {
            GameOver();
        }
    }
    public void StartGame()
    {
        UIManager.Instance.GameStart();
    }

    public void GameOver()
    {
        UIManager.Instance.GameOver();
        CameraController.Instance.isCameraPaused = true;
        BuildingQueue.InitializeLevel();
    }
}
