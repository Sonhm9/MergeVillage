using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    public GameObject displayBuilding; // ���÷��̿� ������Ʈ

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

        // ���콺 ���ٴ�� �浹 �˻�
        if(Physics.Raycast(ray,out hit))
        {
            // �̵�, �ε� ��尡 �ƴҶ�
            if(cursorController.modeState!=CursorController.ModeState.Move&& cursorController.modeState != CursorController.ModeState.Loading)
            {
                // �±װ� "Tile" �� ���
                if (hit.collider.CompareTag("Tile"))
                {
                    // �� Ÿ���� ��
                    if (hit.collider.transform.childCount < 1)
                    {
                        cursorController.OnBuildCursorMode(); // ���� ��� ��ȯ
                        Vector3 targetPosition = hit.transform.position;
                        displayBuilding.transform.position = targetPosition;

                        // �ǹ� �Ǽ� Ŭ��
                        if (Input.GetMouseButtonDown(0))
                        {
                            placeBuilding.OnPlaceBuildClicked(targetPosition, hit.collider.gameObject);
                        }
                    }

                    // �ǹ��� �ִ� Ÿ���� ��
                    else
                    {
                        cursorController.OnDefaultCursorMode();
                        displayBuilding.transform.position = new Vector3(100, 100, 100);
                    }
                }

                // �±װ� "Building" �� ���
                else if (hit.collider.CompareTag("Building"))
                {
                    cursorController.OnDefaultCursorMode();
                    displayBuilding.transform.position = new Vector3(100, 100, 100);
                }
            }
            // �̵�, �ε� ��� �϶�
            else
            {
                displayBuilding.transform.position = new Vector3(100, 100, 100);
            }
        }
    }

    // ���÷��̿� �ǹ� ��ü
    public void ChangeBuildingPrefab(GameObject prefab)
    {
        // ���� �ڽ� ������Ʈ ����
        Transform child = displayBuilding.transform.GetChild(0);
        Destroy(child.gameObject);

        // �� �ڽ� ������Ʈ ����
        GameObject building = Instantiate(prefab);

        building.transform.SetParent(displayBuilding.transform);

        building.transform.localPosition = Vector3.zero;
        building.transform.localRotation = Quaternion.identity;

        // �ݶ��̴� ����
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
