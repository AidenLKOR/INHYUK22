using UnityEngine;
using System.Collections; // IEnumerator를 사용하기 위한 using 문 추가

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance { get; private set; }

    public GameObject miniGameUI;
    public GameObject player;
    public GameObject bulletPrefab;
    public Transform gameArea;

    [HideInInspector]
    public bool isGameActive = false;

    private int currentRound = 1;
    private int totalRounds = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        miniGameUI.SetActive(false);
        player.SetActive(false);
    }

    public void StartMiniGame()
    {
        miniGameUI.SetActive(true);
        player.SetActive(true);
        isGameActive = true;
        currentRound = 1;
        StartCoroutine(SpawnBullets());
    }

    public void EndMiniGame()
    {
        miniGameUI.SetActive(false);
        player.SetActive(false);
        isGameActive = false;
        StopAllCoroutines();
    }

    private IEnumerator SpawnBullets()
    {
        while (isGameActive)
        {
            Instantiate(bulletPrefab, gameArea.position, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);

            if (currentRound >= totalRounds)
            {
                EndMiniGame();
            }
            else
            {
                currentRound++;
            }
        }
    }
}
