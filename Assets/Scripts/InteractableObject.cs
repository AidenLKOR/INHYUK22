using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public string message; // 표시할 메시지
    public string url; // 인터넷 링크
    public Sprite image; // 표시할 이미지

    public GameObject messageBox; // 메시지 박스
    public TextMeshProUGUI messageText; // 메시지 텍스트
    public GameObject urlButton; // 인터넷 링크 버튼

    private PlayerInteraction playerInteraction;

    void Start()
    {
        // Start 시점에 메시지 박스와 관련 요소들을 숨깁니다.
        HideMessage();

        // PlayerInteraction 컴포넌트를 찾습니다.
        playerInteraction = FindObjectOfType<PlayerInteraction>();

        // URL 버튼에 클릭 이벤트를 추가합니다.
        if (urlButton != null)
        {
            Button btn = urlButton.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(OpenUrl); // 파라미터 없는 메서드로 변경
            }
        }
    }

    public void ShowMessage()
    {
        if (messageBox != null && messageText != null)
        {
            messageText.text = message;
            messageBox.SetActive(true); // 메시지 박스를 활성화합니다.

            // URL이 있는 경우 버튼을 활성화합니다.
            if (!string.IsNullOrEmpty(url) && urlButton != null)
            {
                urlButton.SetActive(true);
            }
            else
            {
                if (urlButton != null)
                {
                    urlButton.SetActive(false);
                }
            }
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

    // 파라미터 없는 메서드 추가
    public void OpenUrl()
    {
        if (!string.IsNullOrEmpty(url))
        {
            Application.OpenURL(url); // URL을 엽니다.
        }
    }
}
