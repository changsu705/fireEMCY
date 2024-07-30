using UnityEngine;

public class PlugController : MonoBehaviour
{
    public GameObject plugHead; // 플러그 헤드 오브젝트
    public Transform endPoint; // 와이어의 끝 지점 (콘센트 위치)
    public float wireLength = 1.2f; // 와이어 길이 (120cm)

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // 시작점과 끝점
    }

    void Update()
    {
        // 플러그 헤드와 끝 지점 사이의 거리 계산
        float distance = Vector3.Distance(plugHead.transform.position, endPoint.position);

        // 와이어가 120cm를 초과하지 않도록 제한
        if (distance > wireLength)
        {
            Vector3 direction = (endPoint.position - plugHead.transform.position).normalized;
            endPoint.position = plugHead.transform.position + direction * wireLength;
        }

        // Line Renderer 포인트 설정
        lineRenderer.SetPosition(0, plugHead.transform.position);
        lineRenderer.SetPosition(1, endPoint.position);
    }
}
