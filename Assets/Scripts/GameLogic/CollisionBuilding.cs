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
        // 건물이 인접해 있을 때
        if (other.gameObject.tag == "Building")
        {
            BuildingData buildingData = other.GetComponent<BuildingData>();
            MergeBuilding mergeBuilding = other.GetComponent<MergeBuilding>();

            // 같은 레벨의 건물이라면
            if (buildingData.buildingType.level == myBuildingData.buildingType.level)
            {
                // 최대 레벨이 아닐 때
                if (myBuildingData.buildingType.level < 8)
                {
                    myMergeBuilding.point += buildingData.buildingType.point; // 내 빌딩에 포인트 합산
                    myMergeBuilding.count++; // 카운트 추가
                    mergeBuilding.Merge(myMergeBuilding.myPosition); // 합병 실행
                }
            }
        }
    }
}
