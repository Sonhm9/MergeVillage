using System.Collections.Generic;
using UnityEngine;

public class BuildingQueue : MonoBehaviour
{
    static int currentMaxLevel = 0; // 현재 건물 레벨
    int maxLevel = 8; // 최대 건물 레벨
    int queueCapacity = 4; // 빌딩 큐의 최대 용량

    static Queue<int> buildingQueue = new Queue<int>(); // 빌딩 큐

    void Start()
    {
        // 큐에 1레벨 채워넣기
        for(int i = 0; i < queueCapacity; i++)
        {
            buildingQueue.Enqueue(0);
        }
    }

    // 빌딩 큐 Enqueue
    public static void Enqueue()
    {
        int num = Random.Range(0, currentMaxLevel); // 현재 레벨까지 랜덤숫자 생성
        buildingQueue.Enqueue(num); // 랜덤숫자 큐에 넣기
        Debug.Log(num);
    }

    // 빌딩 큐 Dequeue
    public static int Dequeue()
    {
        int num = buildingQueue.Dequeue();

        Enqueue();

        return num;
    }

}
