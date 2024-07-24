using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameRSP : MonoBehaviour
{
    public GameObject miniGamePanel;
    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI resultText;

    private int playerScore = 0;
    private int computerScore = 0;
    private int round = 1;
    private const int maxRounds = 3;
    private string playerChoice;
    private string computerChoice;

    void Start()
    {
        miniGamePanel.SetActive(false);
        rockButton.onClick.AddListener(() => OnChoiceSelected("Rock"));
        paperButton.onClick.AddListener(() => OnChoiceSelected("Paper"));
        scissorsButton.onClick.AddListener(() => OnChoiceSelected("Scissors"));
    }

    public void StartMiniGame()
    {
        miniGamePanel.SetActive(true);
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
        resultText.text = $"Player: {playerChoice}\nComputer: {computerChoice}";

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
            case 0: return "Rock";
            case 1: return "Paper";
            case 2: return "Scissors";
        }
        return "Rock";
    }

    private void DetermineWinner()
    {
        if (playerChoice == computerChoice)
        {
            resultText.text += "\nResult: Draw";
        }
        else if ((playerChoice == "Rock" && computerChoice == "Scissors") ||
                 (playerChoice == "Paper" && computerChoice == "Rock") ||
                 (playerChoice == "Scissors" && computerChoice == "Paper"))
        {
            playerScore++;
            resultText.text += "\nResult: Player Wins";
        }
        else
        {
            computerScore++;
            resultText.text += "\nResult: Computer Wins";
        }
    }

    private void DisplayFinalResult()
    {
        miniGamePanel.SetActive(false);
        string finalResult = playerScore > computerScore ? "Player Wins the Game!" : "Computer Wins the Game!";
        resultText.text = finalResult;
        resultText.gameObject.SetActive(true);
    }
}
