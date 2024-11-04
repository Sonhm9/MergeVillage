using UnityEngine;

public class PlaceBuilding : MonoBehaviour
{
    public GameObject[] buildingPrefab; // ���� ������
    public int buildingIdx; // ���� �ε���

    MouseTarget mouseTarget;
    void Start()
    {
        mouseTarget = GetComponent<MouseTarget>();
        buildingIdx = 2; // ������Դϴ�

        //mouseTarget.ChangeBuildingPrefab(buildingPrefab[buildingIdx]);
    }

    // �ǹ� �Ǽ� �޼���
    public void OnPlaceBuildClicked(Vector3 position, GameObject parent)
    {
        GameObject building = Instantiate(buildingPrefab[buildingIdx], position, Quaternion.identity); // ������ �ǹ� ����
        building.transform.SetParent(parent.transform); // ��ġ������Ʈ�� �ڽ�����
        building.transform.localRotation = Quaternion.identity; // ȸ���� ����ȸ������
    }
    void Update()
    {
        
    }
}
