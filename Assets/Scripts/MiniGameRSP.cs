using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MiniGameRSP : MonoBehaviour
{
    public GameObject miniGamePanel;
    public Image backgroundImage; // 배경 이미지
    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI resultText;
    public Button retryButton;
    public Button returnButton;

    private int playerScore = 0;
    private int computerScore = 0;
    private int round = 1;
    private const int maxRounds = 3;
    private string playerChoice;
    private string computerChoice;

    void Start()
    {
        // 배경 이미지 설정
        backgroundImage.rectTransform.SetAsFirstSibling();

        miniGamePanel.SetActive(true);
        retryButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);

        rockButton.onClick.AddListener(() => OnChoiceSelected("주먹"));
        paperButton.onClick.AddListener(() => OnChoiceSelected("보"));
        scissorsButton.onClick.AddListener(() => OnChoiceSelected("가위"));
        retryButton.onClick.AddListener(RestartGame);
        returnButton.onClick.AddListener(ReturnToPreviousScene);

        StartCoroutine(StartRound());
    }

    private void OnChoiceSelected(string choice)
    {
        playerChoice = choice;
        StartCoroutine(PlayRound());
    }

    private IEnumerator StartRound()
    {
        countdownText.gameObject.SetActive(true);
        resultText.gameObject.SetActive(false);
        yield return Countdown(3);
        yield return Countdown(2);
        yield return Countdown(1);
        countdownText.gameObject.SetActive(false);
    }

    private IEnumerator Countdown(int number)
    {
        countdownText.text = number.ToString();
        yield return new WaitForSeconds(1);
    }

    private IEnumerator PlayRound()
    {
        yield return StartRound();

        computerChoice = GetComputerChoice();
        resultText.gameObject.SetActive(true);
        resultText.text = $"Player: {playerChoice}\nFriend: {computerChoice}";

        DetermineWinner();

        round++;
        if (round <= maxRounds)
        {
            yield return new WaitForSeconds(2);
            StartCoroutine(StartRound());
        }
        else
        {
            DisplayFinalResult();
        }
    }

    private string GetComputerChoice()
    {
        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0: return "주먹";
            case 1: return "보";
            case 2: return "가위";
        }
        return "주먹";
    }

    private void DetermineWinner()
    {
        if (playerChoice == computerChoice)
        {
            resultText.text += "\n결과: Draw!";
        }
        else if ((playerChoice == "주먹" && computerChoice == "가위") ||
                 (playerChoice == "보" && computerChoice == "주먹") ||
                 (playerChoice == "가위" && computerChoice == "보"))
        {
            playerScore++;
            resultText.text += "\n결과: You Win!";
        }
        else
        {
            computerScore++;
            resultText.text += "\n결과: You Lose!";
        }
    }

    private void DisplayFinalResult()
    {
        if (playerScore > computerScore)
        {
            resultText.text = "승리하였습니다!";
            returnButton.gameObject.SetActive(true);
        }
        else
        {
            resultText.text = "패배하였습니다!";
            retryButton.gameObject.SetActive(true);
        }
        resultText.gameObject.SetActive(true);
    }

    private void RestartGame()
    {
        playerScore = 0;
        computerScore = 0;
        round = 1;
        miniGamePanel.SetActive(true);
        retryButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        resultText.gameObject.SetActive(false);
        StartCoroutine(StartRound());
    }

    private void ReturnToPreviousScene()
    {
        // 위치를 PlayerPrefs에 저장합니다.
        GameManager1.Instance.SetPlayerStartPosition(new Vector3(-0.35f, -3.13f, 0));
        SceneManager.LoadScene("#4-2.Cave");
    }
}
