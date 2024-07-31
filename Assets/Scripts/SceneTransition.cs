using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance { get; private set; }
    public Vector2 playerNewPosition; // 플레이어의 새로운 위치

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
    }

    public IEnumerator ChangeSceneAndSetPlayerPosition(string sceneName, Vector2 newPosition)
    {
        playerNewPosition = newPosition;

        // 위치를 PlayerPrefs에 저장합니다.
        PlayerPrefs.SetFloat("PlayerX", playerNewPosition.x);
        PlayerPrefs.SetFloat("PlayerY", playerNewPosition.y);

        // 씬 변경
        SceneManager.LoadScene(sceneName);

        // 씬이 로드될 때까지 기다림
        yield return new WaitForSeconds(0.1f);

        // 플레이어 위치 설정
        SetPlayerPosition();
    }

    private void SetPlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float x = PlayerPrefs.GetFloat("PlayerX", player.transform.position.x);
            float y = PlayerPrefs.GetFloat("PlayerY", player.transform.position.y);
            player.transform.position = new Vector2(x, y);
        }
        else
        {
            Debug.LogError("Player object not found!");
        }
    }
}
