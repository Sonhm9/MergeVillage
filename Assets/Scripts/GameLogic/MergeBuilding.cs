using System.Collections;
using UnityEngine;

public class MergeBuilding : MonoBehaviour
{
    [SerializeField] Collider[] upDownLeftRight;
    [SerializeField] GameObject[] upgradePrefab;
    BuildingData myBuildingData;
    Transform position;

    public Vector3 myPosition;
    public int count;
    public int point;

    float moveSpeed = 100;

    void Start()
    {
        myBuildingData = GetComponentInParent<BuildingData>();

        position = gameObject.transform.parent;
        point = myBuildingData.buildingType.point;
        myPosition = transform.position;
        count = 1;

        StartCoroutine(UnenabledCollider());
        StartCoroutine(UpgradeRoutine());

    }
    public void PlusPoint()
    {
        GameManager.Instance.point += point;
    }
    public void DeactiveCollision()
    {
        foreach(Collider sphere in upDownLeftRight)
        {
            sphere.gameObject.SetActive(false);
        }
    }

    public void ActiveCollision()
    {
        foreach (Collider sphere in upDownLeftRight)
        {
            sphere.gameObject.SetActive(true);
        }
    }

    // 자신의 건물 업그레이드
    public void Upgrade(Vector3 target)
    {
        GameObject building = Instantiate(upgradePrefab[myBuildingData.buildingType.level+1], target, Quaternion.identity);
        building.transform.SetParent(position.transform);
        building.transform.localPosition = Vector3.zero;
        building.transform.localRotation = Quaternion.identity;
        BuildingQueue.LevelUP(myBuildingData.buildingType.level + 1);

        Destroy(gameObject);
    }

    // 타겟으로 이동
    IEnumerator MoveToTarget(Vector3 target)
    {
        // 거리가 좁혀질 때 까지
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            // 타겟 위치로 서서히 이동
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

            yield return null;
        }
    
        Destroy(gameObject); // 타겟에 도착한 후 오브젝트 삭제
    }

    // 콜라이더 해제 코루틴
    IEnumerator UnenabledCollider()
    {
        yield return new WaitForSeconds(0.1f);

        DeactiveCollision();
    }

    IEnumerator UpgradeRoutine()
    {

        yield return new WaitForSeconds(0.25f);
        if (count > 1)
        {
            PlusPoint();
            UIManager.Instance.PointTextUpdate();
            Upgrade(myPosition);
        }
        GameManager.Instance.CheckOver();
    }

    // 합병 메서드
    public void Merge(Vector3 target)
    {
        StartCoroutine(MoveToTarget(target));
    }


}
