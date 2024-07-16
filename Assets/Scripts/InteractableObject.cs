using UnityEngine;
using TMPro; // 추가한 부분

public class InteractableObject : MonoBehaviour
{
    public string message;
    public GameObject messageBox;
    public TextMeshProUGUI messageText;

    void Start()
    {
        HideMessage();
    }

    public void ShowMessage()
    {
        if (messageBox != null && messageText != null)
        {
            messageText.text = message;
            messageBox.SetActive(true);
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
            messageBox.SetActive(false);
        }
    }

    public void TriggerMiniGame()
    {
        if (MiniGameManager.Instance != null)
        {
            MiniGameManager.Instance.StartMiniGame();
        }
    }
}
