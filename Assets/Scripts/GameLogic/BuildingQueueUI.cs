using UnityEngine;
using UnityEngine.UI;

public class BuildingQueueUI : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject[] levelImage;
    void Start()
    {
        
    }

    // ť �̹��� ����
    public void EnqueueImage(int index)
    {
        GameObject newGameObject = Instantiate(levelImage[index], content);
    }

    // ť �̹��� ����
    public void DequeueImage()
    {
        if (content.childCount > 1)
        {
            Transform first = content.GetChild(0);

            Destroy(first.gameObject);
        }
    }
}
