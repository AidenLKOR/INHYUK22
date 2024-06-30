using UnityEngine;

public class Interactable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어와 충돌 시 수행할 동작
            Debug.Log("플레이어와 상호작용 발생!");
            PerformAction();
        }
    }

    void PerformAction()
    {
        // 상호작용 시 수행할 동작을 여기에 작성
        // 예: 아이템 획득, 문 열기, 점수 증가 등
        Debug.Log("상호작용 동작 수행!");
    }
}
