using UnityEngine;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    public string message; // 표시할 메시지
    public GameObject messageBox; // 메시지 박스
    public TextMeshProUGUI messageText; // 메시지 텍스트

    private PlayerInteraction playerInteraction;

    void Start()
    {
        // Start 시점에 메시지 박스를 숨깁니다.
        HideMessage();

        // PlayerInteraction 컴포넌트를 찾습니다.
        playerInteraction = FindObjectOfType<PlayerInteraction>();
    }

    public void ShowMessage()
    {
        if (messageBox != null && messageText != null)
        {
            messageText.text = message;
            messageBox.SetActive(true); // 메시지 박스를 활성화합니다.
        }
        else
        {
            Debug.LogWarning("Trying to access destroyed object in ShowMessage method.");
        }
    }

    public void HideMessage()
    {
        if (messageBox != null)
        {
            messageBox.SetActive(false); // 메시지 박스를 비활성화합니다.
        }
    }

    private void OnDestroy()
    {
        if (playerInteraction != null)
        {
            playerInteraction.ClearCurrentInteractableObject(this.gameObject);
        }

        messageBox = null;
        messageText = null;
    }
}
