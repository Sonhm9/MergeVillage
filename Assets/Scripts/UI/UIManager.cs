using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject[] uiList;
    [SerializeField] CanvasGroup gameOverPanel;
    [SerializeField] CanvasGroup gameStartPanel;

    float fadeDuration = 1;
    static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        } 
    }

    [SerializeField] TextMeshProUGUI pointText;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        PointTextUpdate();
    }

    void Update()
    {
        
    }
    public void PointTextUpdate()
    {
        pointText.text = GameManager.Instance.point.ToString();
    }

    // UI ��Ȱ��ȭ
    public void DeactiveUI()
    {
        foreach(GameObject ui in uiList)
        {
            ui.gameObject.SetActive(false);
        }
    }

    // UI Ȱ��ȭ
    public void ActiveUI()
    {
        foreach (GameObject ui in uiList)
        {
            ui.gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.alpha = 0f;
            gameOverPanel.gameObject.SetActive(true);  // �г��� Ȱ��ȭ�� �� ���̵� ��
            StartCoroutine(FadeIn());
        }
    }

    public void GameStart()
    {
        DeactiveUI();
        if (gameStartPanel != null)
        {
            gameStartPanel.alpha = 1f;
            gameStartPanel.gameObject.SetActive(true);  // �г��� Ȱ��ȭ�� �� ���̵� �ƿ�
            StartCoroutine(FadeOut());
        }
    }

    public void OnAgainClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            gameOverPanel.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);  // ���������� alpha ���� ����
            yield return null;
        }

        // ���̵� �� �Ϸ� �� ������ �������ϰ� ����
        gameOverPanel.alpha = 1f;
    }

    IEnumerator FadeOut()
    {
        CameraController.Instance.isCameraPaused = true;

        float elapsedTime = 0f;
        float startAlpha = gameStartPanel.alpha;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            gameStartPanel.alpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeDuration);  // ���������� alpha ���� ����
            yield return null;
        }

        // ���̵� �� �Ϸ� �� ������ �����ϰ� ����
        gameStartPanel.alpha = 0f;
        gameStartPanel.gameObject.SetActive(false);
        ActiveUI();
        CameraController.Instance.isCameraPaused = false;

    }
}
