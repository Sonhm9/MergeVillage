using System.Collections.Generic;
using UnityEngine;

public class BuildingQueue : MonoBehaviour
{
    static int currentMaxLevel = 0; // 현재 건물 레벨
    static int maxLevel = 8; // 최대 건물 레벨
    int queueCapacity = 4; // 빌딩 큐의 최대 용량

    static Queue<int> buildingQueue = new Queue<int>(); // 빌딩 큐
    static BuildingQueueUI buildingQueueUI;

    void Start()
    {
        buildingQueueUI = GetComponent<BuildingQueueUI>();

        // 큐에 1레벨 채워넣기
        for(int i = 0; i < queueCapacity; i++)
        {
            Enqueue();
        }
    }

    // 빌딩 큐 Enqueue
    public static void Enqueue()
    {
        int num = Random.Range(0, currentMaxLevel); // 현재 레벨까지 랜덤숫자 생성
        buildingQueue.Enqueue(num); // 랜덤숫자 큐에 넣기
        buildingQueueUI.EnqueueImage(num);
    }

    // 빌딩 큐 Dequeue
    public static int Dequeue()
    {
        int num = buildingQueue.Dequeue();

        buildingQueueUI.DequeueImage();

        Enqueue();

        return num;
    }

    // 빌딩 큐 Peek
    public static int Peek()
    {
        int num = buildingQueue.Peek();

        return num;
    }

    // 레벨 업
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
