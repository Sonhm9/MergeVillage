using System.Collections.Generic;
using UnityEngine;

public class BuildingQueue : MonoBehaviour
{
    static int currentMaxLevel = 0; // ���� �ǹ� ����
    int maxLevel = 8; // �ִ� �ǹ� ����
    int queueCapacity = 4; // ���� ť�� �ִ� �뷮

    static Queue<int> buildingQueue = new Queue<int>(); // ���� ť

    void Start()
    {
        // ť�� 1���� ä���ֱ�
        for(int i = 0; i < queueCapacity; i++)
        {
            buildingQueue.Enqueue(0);
        }
    }

    // ���� ť Enqueue
    public static void Enqueue()
    {
        int num = Random.Range(0, currentMaxLevel); // ���� �������� �������� ����
        buildingQueue.Enqueue(num); // �������� ť�� �ֱ�
        Debug.Log(num);
    }

    // ���� ť Dequeue
    public static int Dequeue()
    {
        int num = buildingQueue.Dequeue();

        Enqueue();

        return num;
    }

}
