using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    public GameObject displayBuilding; // 디스플레이용 오브젝트

    CursorController cursorController;
    PlaceBuilding placeBuilding;

    void Start()
    {
        cursorController = GetComponent<CursorController>();
        placeBuilding = GetComponent<PlaceBuilding>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // 마우스 갖다대면 충돌 검사
        if(Physics.Raycast(ray,out hit))
        {
            // 이동, 로딩 모드가 아닐때
            if(cursorController.modeState!=CursorController.ModeState.Move&& cursorController.modeState != CursorController.ModeState.Loading)
            {
                // 태그가 "Tile" 일 경우
                if (hit.collider.CompareTag("Tile"))
                {
                    // 빈 타일일 때
                    if (hit.collider.transform.childCount < 1)
                    {
                        cursorController.OnBuildCursorMode(); // 빌드 모드 전환
                        Vector3 targetPosition = hit.transform.position;
                        displayBuilding.transform.position = targetPosition;

                        // 건물 건설 클릭
                        if (Input.GetMouseButtonDown(0))
                        {
                            placeBuilding.OnPlaceBuildClicked(targetPosition, hit.collider.gameObject);
                        }
                    }

                    // 건물이 있는 타일일 때
                    else
                    {
                        cursorController.OnDefaultCursorMode();
                        displayBuilding.transform.position = new Vector3(100, 100, 100);
                    }
                }

                // 태그가 "Building" 일 경우
                else if (hit.collider.CompareTag("Building"))
                {
                    cursorController.OnDefaultCursorMode();
                    displayBuilding.transform.position = new Vector3(100, 100, 100);
                }
            }
            // 이동, 로딩 모드 일때
            else
            {
                displayBuilding.transform.position = new Vector3(100, 100, 100);
            }
        }
    }

    // 디스플레이용 건물 교체
    public void ChangeBuildingPrefab(GameObject prefab)
    {
        // 기존 자식 오브젝트 삭제
        Transform child = displayBuilding.transform.GetChild(0);
        Destroy(child.gameObject);

        // 새 자식 오브젝트 생성
        GameObject building = Instantiate(prefab);

        building.transform.SetParent(displayBuilding.transform);

        building.transform.localPosition = Vector3.zero;
        building.transform.localRotation = Quaternion.identity;

        // 콜라이더 해제
        Collider prefabCollider = building.GetComponent<BoxCollider>();
        MergeBuilding merge = building.GetComponent<MergeBuilding>();
        AudioSource audioSource = building.GetComponent<AudioSource>();
        if (prefabCollider != null)
        {
            merge.DeactiveCollision();
            prefabCollider.enabled = false;
            audioSource.enabled = false;
        }
    }
}
