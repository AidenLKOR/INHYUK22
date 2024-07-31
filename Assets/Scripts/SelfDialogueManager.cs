using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshProUGUI 사용을 위해 추가

public class SelfDialogueManager : MonoBehaviour
{
    public GameObject selfDialogueBox;
    public TextMeshProUGUI selfDialogueText; // Text 대신 TextMeshProUGUI 사용
    public string[] dialogueLines;
    private int currentLineIndex = 0;
    public float dialogueDelay = 0.1f;

    void Start()
    {
        if (selfDialogueBox == null)
        {
            Debug.LogError("Dialogue box not assigned.");
            return;
        }

        if (selfDialogueText == null)
        {
            Debug.LogError("Dialogue text not assigned.");
            return;
        }

        selfDialogueBox.SetActive(true);
        StartCoroutine(DisplayLine());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextLine();
        }
    }

    IEnumerator DisplayLine()
    {
        selfDialogueText.text = string.Empty;
        foreach (char letter in dialogueLines[currentLineIndex].ToCharArray())
        {
            selfDialogueText.text += letter;
            yield return new WaitForSeconds(dialogueDelay);
        }
    }

    void DisplayNextLine()
    {
        if (currentLineIndex < dialogueLines.Length - 1)
        {
            currentLineIndex++;
            StartCoroutine(DisplayLine());
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        selfDialogueBox.SetActive(false);
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1.0f); // Optional delay before scene change
        SceneManager.LoadScene("#6.policehouse");
    }
}
