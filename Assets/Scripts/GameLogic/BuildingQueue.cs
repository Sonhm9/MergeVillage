using System.Collections.Generic;
using UnityEngine;

public class BuildingQueue : MonoBehaviour
{
    static int currentMaxLevel = 0; // ���� �ǹ� ����
    static int maxLevel = 8; // �ִ� �ǹ� ����
    int queueCapacity = 4; // ���� ť�� �ִ� �뷮

    static Queue<int> buildingQueue = new Queue<int>(); // ���� ť
    static BuildingQueueUI buildingQueueUI;

    void Start()
    {
        buildingQueueUI = GetComponent<BuildingQueueUI>();

        // ť�� 1���� ä���ֱ�
        for(int i = 0; i < queueCapacity; i++)
        {
            Enqueue();
        }
    }

    // ���� ť Enqueue
    public static void Enqueue()
    {
        int num = Random.Range(0, currentMaxLevel); // ���� �������� �������� ����
        buildingQueue.Enqueue(num); // �������� ť�� �ֱ�
        buildingQueueUI.EnqueueImage(num);
    }

    // ���� ť Dequeue
    public static int Dequeue()
    {
        int num = buildingQueue.Dequeue();

        buildingQueueUI.DequeueImage();

        Enqueue();

        return num;
    }

    // ���� ť Peek
    public static int Peek()
    {
        int num = buildingQueue.Peek();

        return num;
    }

    // ���� ��
    public static void LevelUP(int level)
    {
        if (currentMaxLevel <= maxLevel)
        {
            if (level > currentMaxLevel)
            {
                currentMaxLevel = level;
            }
        }
    }

}
