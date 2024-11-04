using UnityEngine;

public class PlaceBuilding : MonoBehaviour
{
    public GameObject[] buildingPrefab; // ���� ������
    public int buildingIdx; // ���� �ε���

    MouseTarget mouseTarget;

    void Start()
    {
        mouseTarget = GetComponent<MouseTarget>();
    }

    // �ǹ� �Ǽ� �޼���
    public void OnPlaceBuildClicked(Vector3 position, GameObject parent)
    {
        SetTargetBuilding(BuildingQueue.Dequeue()); // ť���� �ǹ��� ������ ����

        GameObject building = Instantiate(buildingPrefab[buildingIdx], position, Quaternion.identity); // ������ �ǹ� ����

        building.transform.SetParent(parent.transform); // ��ġ������Ʈ�� �ڽ�����
        building.transform.localRotation = Quaternion.identity; // ȸ���� ����ȸ������
    }

    // �Ǽ��� �ǹ� ����
    public void SetTargetBuilding(int index)
    {
        buildingIdx = index;
        mouseTarget.ChangeBuildingPrefab(buildingPrefab[buildingIdx]); // �Ǽ��� �ǹ� ��ü
    }
}
