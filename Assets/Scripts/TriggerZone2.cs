using UnityEngine;

public class TriggerZone2 : MonoBehaviour
{
    public DrugSellerController2 drugSeller;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            drugSeller.StartChase();
        }
    }
}
