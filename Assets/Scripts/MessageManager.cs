using UnityEngine;
using TMPro;

public class MessageManager : MonoBehaviour
{
    public static MessageManager Instance { get; private set; }

    public GameObject messageBox; // 메시지 박스 UI
    public TMP_Text messageText; // 메시지 텍스트

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        // Awake 시점에 메시지 박스를 숨깁니다.
        HideMessage();
    }

    public void ShowMessage(string message)
    {
        messageBox.SetActive(true);
        messageText.text = message;
    }

    public void HideMessage()
    {
        messageBox.SetActive(false);
    }
}
