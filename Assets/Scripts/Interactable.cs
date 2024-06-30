using UnityEngine;

public class Interactable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾�� �浹 �� ������ ����
            Debug.Log("�÷��̾�� ��ȣ�ۿ� �߻�!");
            PerformAction();
        }
    }

    void PerformAction()
    {
        // ��ȣ�ۿ� �� ������ ������ ���⿡ �ۼ�
        // ��: ������ ȹ��, �� ����, ���� ���� ��
        Debug.Log("��ȣ�ۿ� ���� ����!");
    }
}
