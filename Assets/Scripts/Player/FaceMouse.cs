
using UnityEngine;

public class FaceMouse : MonoBehaviour
{

    public Camera mainCamera;
    private Vector3 targetPosition;

    void Update()
    {
        FaceTo();
    }

    public void FaceTo()
    {
        // ����һ�����ߣ���ȡ�����ָ����λ��
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            targetPosition = hit.point;
            targetPosition.y = transform.position.y;

            // �������ｫҪ�����Ŀ�귽��
            Vector3 directionToTarget = targetPosition - transform.position;

            if (directionToTarget.magnitude > 1f)
            {
                // �������forward������ת��Ŀ�귽��
                transform.rotation = Quaternion.LookRotation(directionToTarget);
            }

        }
    }
}