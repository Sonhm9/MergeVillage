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

    // UI 비활성화
    public void DeactiveUI()
    {
        foreach(GameObject ui in uiList)
        {
            ui.gameObject.SetActive(false);
        }
    }

    // UI 활성화
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
            gameOverPanel.gameObject.SetActive(true);  // 패널을 활성화한 후 페이드 인
            StartCoroutine(FadeIn());
        }
    }

    public void GameStart()
    {
        DeactiveUI();
        if (gameStartPanel != null)
        {
            gameStartPanel.alpha = 1f;
            gameStartPanel.gameObject.SetActive(true);  // 패널을 활성화한 후 페이드 아웃
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
            gameOverPanel.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);  // 점진적으로 alpha 값을 증가
            yield return null;
        }

        // 페이드 인 완료 후 완전히 불투명하게 설정
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
            gameStartPanel.alpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeDuration);  // 점진적으로 alpha 값을 증가
            yield return null;
        }

        // 페이드 인 완료 후 완전히 투명하게 설정
        gameStartPanel.alpha = 0f;
        gameStartPanel.gameObject.SetActive(false);
        ActiveUI();
        CameraController.Instance.isCameraPaused = false;

    }
}
