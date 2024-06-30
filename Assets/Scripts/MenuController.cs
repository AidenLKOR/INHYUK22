using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        // ���� �� �ε� (��: "GameScene")
        SceneManager.LoadScene("GameScene");
    }

    public void ShowCredits()
    {
        // ũ���� �� �ε� (��: "CreditsScene")
        SceneManager.LoadScene("CreditsScene");
    }
}

