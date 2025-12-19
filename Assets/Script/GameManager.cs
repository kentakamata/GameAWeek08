using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int hitCount = 0;
    public int needHit = 5;
    public int level = 1;

    public Button upgradeButton;
    public Text infoText;
    public PlayerController player;

    void Awake()
    {
        Instance = this;
        upgradeButton.interactable = false;
    }

    void Update()
    {
        infoText.text =
            "LEVEL : " + level +
            "\nHIT : " + hitCount + " / " + needHit +
            "\nFIRE RATE : " + player.shotInterval.ToString("F2");

        if (hitCount >= needHit)
            upgradeButton.interactable = true;
    }

    public void AddHit()
    {
        hitCount++;
    }

    public void UpgradeFireRate()
    {
        player.UpgradeFireRate();
        hitCount = 0;
        level++;
        upgradeButton.interactable = false;
    }
}
