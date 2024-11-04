using UnityEngine;

public class PlaceBuilding : MonoBehaviour
{
    public GameObject[] buildingPrefab; // 빌딩 프리팹
    public int buildingIdx; // 빌딩 인덱스

    MouseTarget mouseTarget;

    void Start()
    {
        mouseTarget = GetComponent<MouseTarget>();
    }

    // 건물 건설 메서드
    public void OnPlaceBuildClicked(Vector3 position, GameObject parent)
    {
        SetTargetBuilding(BuildingQueue.Dequeue()); // 큐에서 건물을 꺼내서 세팅

        GameObject building = Instantiate(buildingPrefab[buildingIdx], position, Quaternion.identity); // 정해진 건물 생성

        building.transform.SetParent(parent.transform); // 위치오브젝트의 자식으로
        building.transform.localRotation = Quaternion.identity; // 회전을 로컬회전으로
    }

    // 건설할 건물 세팅
    public void SetTargetBuilding(int index)
    {
        buildingIdx = index;
        mouseTarget.ChangeBuildingPrefab(buildingPrefab[buildingIdx]); // 건설할 건물 교체
    }
}
