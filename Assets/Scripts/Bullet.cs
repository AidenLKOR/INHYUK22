using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 direction;

    private void Start()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        Destroy(gameObject, 5f); // 5초 후에 총알이 사라지도록 설정
    }

    private void Update()
    {
        if (MiniGameManager.Instance != null && MiniGameManager.Instance.isGameActive)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MiniGameManager.Instance.EndMiniGame();
        }
    }
}
