using UnityEngine;

public class SimpleCollisionTest : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�浹 ����: " + collision.gameObject.name);
    }
}
