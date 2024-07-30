using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DistanceBasedGrabDeactivator : MonoBehaviour
{
    public Transform object1; // 첫 번째 물체
    public Transform object2; // 두 번째 물체
    public float disableDistance = 1.0f; // 그랩 비활성화 거리

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        // XRGrabInteractable 컴포넌트 가져오기
        grabInteractable = GetComponent<XRGrabInteractable>();
        
        if (grabInteractable == null)
        {
            Debug.LogError("XRGrabInteractable 컴포넌트가 존재하지 않습니다.");
        }
    }

    void Update()
    {
        // 두 물체 간의 거리 계산
        float distance = Vector3.Distance(object1.position, object2.position);

        // 거리 조건에 따라 XRGrabInteractable 활성화/비활성화
        if (distance <= disableDistance)
        {
            grabInteractable.enabled = false;
        }
        else
        {
            grabInteractable.enabled = true;
        }
    }
}
