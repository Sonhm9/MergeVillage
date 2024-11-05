using UnityEngine;
using UnityEngine.UI;

public class BuildingQueueUI : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject[] levelImage;
    void Start()
    {
        
    }

    // 큐 이미지 삽입
    public void EnqueueImage(int index)
    {
        GameObject newGameObject = Instantiate(levelImage[index], content);
    }

    // 큐 이미지 삭제
    public void DequeueImage()
    {
        if (content.childCount > 1)
        {
            Transform first = content.GetChild(0);

            Destroy(first.gameObject);
        }
    }
}
