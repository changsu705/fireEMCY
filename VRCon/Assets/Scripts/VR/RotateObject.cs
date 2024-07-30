using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // 회전 속도
    private Quaternion targetRotation; // 목표 회전 값
    private bool shouldRotate = false;

    void Start()
    {
        targetRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 목표 회전 값을 설정합니다.
            targetRotation *= Quaternion.Euler(0, 90, 0);
            shouldRotate = true;
        }

        if (shouldRotate)
        {
            // 부드럽게 회전합니다.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // 목표 회전에 거의 도달했을 때 회전을 멈춥니다.
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                shouldRotate = false;
            }
        }
    }
}
