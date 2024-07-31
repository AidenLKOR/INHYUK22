using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PoliceController : MonoBehaviour
{
    public float speed = 3.0f;
    public Transform player;
    public float stopDistance = 1.5f;

    private bool isChasing = false;

    void Update()
    {
        if (isChasing)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance > stopDistance)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                isChasing = false;
                StartCoroutine(EndChaseAndChangeScene());
            }
        }
    }

    public void StartChase()
    {
        isChasing = true;
    }

    private IEnumerator EndChaseAndChangeScene()
    {
        Vector2 newPlayerPosition = new Vector2(-10.59f, 4.16f);

        if (SceneTransition.Instance != null)
        {
            yield return SceneTransition.Instance.ChangeSceneAndSetPlayerPosition("#8.black-out", newPlayerPosition);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = true;
        }
    }
}
