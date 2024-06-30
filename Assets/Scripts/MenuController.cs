using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        // °ÔÀÓ ¾À ·Îµå (¿¹: "GameScene")
        SceneManager.LoadScene("GameScene");
    }

    public void ShowCredits()
    {
        // Å©·¹µ÷ ¾À ·Îµå (¿¹: "CreditsScene")
        SceneManager.LoadScene("CreditsScene");
    }
}

