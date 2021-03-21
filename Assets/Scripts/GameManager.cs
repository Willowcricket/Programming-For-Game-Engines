using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject player;
    public int playerKills = 0;

    public GameObject win;
    public GameObject lost;
    public GameObject pause;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (player.GetComponent<HumanoidPawn>().lives < 0)
        {
            pause.SetActive(false);
            lost.SetActive(true);
            Time.timeScale = 0f;
        }
        if (playerKills > 5)
        {
            pause.SetActive(false);
            win.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
