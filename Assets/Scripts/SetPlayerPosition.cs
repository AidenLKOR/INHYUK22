using UnityEngine;

public class SetPlayerPosition : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY"))
        {
            float posX = PlayerPrefs.GetFloat("PlayerPosX");
            float posY = PlayerPrefs.GetFloat("PlayerPosY");
            player.transform.position = new Vector3(posX, posY, player.transform.position.z);
        }
    }
}
