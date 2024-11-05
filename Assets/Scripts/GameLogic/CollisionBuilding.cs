using UnityEngine;

public class CollisionBuilding : MonoBehaviour
{
    BuildingData myBuildingData;
    MergeBuilding myMergeBuilding;
    void Start()
    {
        myBuildingData = GetComponentInParent<BuildingData>();
        myMergeBuilding = GetComponentInParent<MergeBuilding>();
    }


    private void OnTriggerEnter(Collider other)
    {
        // �ǹ��� ������ ���� ��
        if (other.gameObject.tag == "Building")
        {
            BuildingData buildingData = other.GetComponent<BuildingData>();
            MergeBuilding mergeBuilding = other.GetComponent<MergeBuilding>();

            // ���� ������ �ǹ��̶��
            if (buildingData.buildingType.level == myBuildingData.buildingType.level)
            {
                // �ִ� ������ �ƴ� ��
                if (myBuildingData.buildingType.level < 8)
                {
                    myMergeBuilding.point += buildingData.buildingType.point; // �� ������ ����Ʈ �ջ�
                    myMergeBuilding.count++; // ī��Ʈ �߰�
                    mergeBuilding.Merge(myMergeBuilding.myPosition); // �պ� ����
                }
            }
        }
    }
}
