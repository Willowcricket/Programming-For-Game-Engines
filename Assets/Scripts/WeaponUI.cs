using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public Text text;
    private string weapText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.player.GetComponent<HumanoidPawn>().weapon == null)
        {
            weapText = "None";
        }
        else if (GameManager.Instance.player.GetComponent<HumanoidPawn>().weapon.name.Contains("Shot"))
        {
            weapText = "Shotgun";
        }
        else if (GameManager.Instance.player.GetComponent<HumanoidPawn>().weapon.name.Contains("Rifle"))
        {
            weapText = "Rifle";
        }

        text.text = "Weapon: " + weapText;
    }
}
