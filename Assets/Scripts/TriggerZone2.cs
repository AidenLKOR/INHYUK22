using UnityEngine;

public class TriggerZone2 : MonoBehaviour
{
    public DrugSellerController2 drugSeller;
    public PoliceController police;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (drugSeller != null)
            {
                drugSeller.StartChase();
            }

            if (police != null)
            {
                police.StartChase();
            }
        }
    }
}
