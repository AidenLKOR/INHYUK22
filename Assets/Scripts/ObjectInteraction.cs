using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어가 다른 오브젝트와 충돌했을 때의 처리
        if (other.CompareTag("Obstacle"))
        {
            // 다른 오브젝트가 장애물일 경우 처리 (예: 지나가지 못하도록)
            Debug.Log("Cannot pass through obstacle!");
            // 여기에 추가적인 처리 로직을 추가할 수 있습니다.
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // 충돌에서 벗어날 때의 처리
    }
}
