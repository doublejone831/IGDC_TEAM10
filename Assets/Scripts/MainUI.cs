using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public GameObject Menu;
    public GameObject player;

    void Start()
    {
        GameLoad();
    }
    void Update()
    {
        if (Menu.activeSelf)
            Menu.SetActive(false);
        else
            Menu.SetActive(true);
    }

    public void Gamesave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.positon.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.positon.y);
        PlayerPrefs.SetFloat("QustId", questManager.questId);
        PlayerPrefsSave();

        Menu.SetActive(false);
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("Player X"))
            return;

        float x = PlayerPrefs.GetFloat("Player X");
        float x = PlayerPrefs.GetFloat("Player Y");
        int questId = PlayerPrefs.GetInt("QustId");
        int questActionIndex = PlayerPrefs.GetInt("QustActionIndex");

        player.transform.position = new Vector3(x, y, 0);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
    }
}

