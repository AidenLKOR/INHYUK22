using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public DrugSellerController drugSeller; // drug seller ĳ����

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone...");
            drugSeller.StartChase(); // drug seller ĳ������ ���� ����
        }
    }
}
