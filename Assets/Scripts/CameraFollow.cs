using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public Vector3 offset; // 카메라와 플레이어 사이의 오프셋
    public float smoothSpeed = 0.125f; // 카메라 움직임의 부드러운 속도

    void LateUpdate()
    {
        if (player != null)
        {
            // 목표 위치는 플레이어의 위치 + 오프셋
            Vector3 desiredPosition = player.position + offset;
            // 현재 위치와 목표 위치 사이를 부드럽게 이동
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
