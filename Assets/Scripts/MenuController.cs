using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        // 게임 씬 로드 (예: "GameScene")
        SceneManager.LoadScene("#1.HomeScene");
    }

    public void ShowCredits()
    {
        // 크레딧 씬 로드 (예: "CreditsScene")
        SceneManager.LoadScene("CreditsScene");
    }

    public void GoBackToStartScene()
    {
        // StartScene으로 돌아가기
        SceneManager.LoadScene("StartScene");
    }
}
