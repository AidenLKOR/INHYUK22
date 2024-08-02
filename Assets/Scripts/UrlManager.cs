using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class UrlManager : MonoBehaviour
{
    public string message; // 표시할 메시지
    public GameObject messageBox; // 메시지 박스
    public TextMeshProUGUI messageText; // 메시지 텍스트
    public Button urlButton; // 인터넷 링크 버튼

    // 각 태그에 해당하는 URL을 저장할 Dictionary
    private Dictionary<string, string> urlDict = new Dictionary<string, string>()
    {
        { "study", "https://sites.google.com/gge.goe.go.kr/drugoutnevertry/%ED%99%88" }
        // 여기 추가적으로 태그와 URL을 추가할 수 있습니다.
    };

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
            urlButton.onClick.AddListener(() => OpenUrl());
        }
    }

    public void ShowMessage()
    {
        if (messageBox != null && messageText != null)
        {
            messageText.text = message;
            messageBox.SetActive(true); // 메시지 박스를 활성화합니다.

            // 현재 태그에 해당하는 URL을 설정합니다.
            if (urlDict.ContainsKey(tag) && urlButton != null)
            {
                urlButton.gameObject.SetActive(true);
            }
            else
            {
                if (urlButton != null)
                {
                    urlButton.gameObject.SetActive(false);
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

    private void OpenUrl()
    {
        if (urlDict.ContainsKey(tag))
        {
            Application.OpenURL(urlDict[tag]); // URL을 엽니다.
        }
    }
}
