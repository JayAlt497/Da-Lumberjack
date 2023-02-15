using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//////////////////////////////
// Written by: Jayden Alton //
// Associate writing:       //
// Last Modified: 2/14/2023 //
//////////////////////////////

public class MenuSystemScript : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI currencyText;
    public TextMeshProUGUI thermalCostText;
    public TextMeshProUGUI swingCostText;
    private int currentThermalUpgradeCost;
    private int currentSwingUpgradeCost;
    private int currency;
    
    // Start is called before the first frame update
    void Start()
    {
        getPlayerPrefs();
    }

    public void getPlayerPrefs()
    {
        currentThermalUpgradeCost = PlayerPrefs.GetInt("NextThermalUpgrade", 100);
        currentSwingUpgradeCost = PlayerPrefs.GetInt("NextSwingUpgrade", 100);
        currency = PlayerPrefs.GetInt("currency", 0);
    }
    public void UpdateMenu()
    {
        getPlayerPrefs();
        currencyText.SetText("Currency: " + currency);
        thermalCostText.SetText("Upgrade Thermal Gear \n  Cost: " + currentThermalUpgradeCost);
        swingCostText.SetText("Upgrade Swing Strength \n  Cost: " + currentSwingUpgradeCost);
    }
    //Loads the Game scene
    public void LoadGame()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene("Game");
    }

    //Loads GameOver Screen
    public void LoadGameOver()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene("GameOver");
    }
    public void LoadUpgradeMenu()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene("UpgradeMenu");
    }
    //permanetly upgrades players thermal gear
    public void UpgradeThermalProtection()
    {
        if(PlayerPrefs.GetInt("currency") > currentThermalUpgradeCost)
        {
            float currentThermalProtection = PlayerPrefs.GetFloat("thermalProtection");
            PlayerPrefs.SetFloat("thermalProtection", currentThermalProtection + 0.5f);
            PlayerPrefs.SetInt("NextThermalUpgrade", (currentThermalUpgradeCost + 100));
            PlayerPrefs.SetInt("currency", currency - currentThermalUpgradeCost);
            UpdateMenu();
        }
    }
    public void UpgradeSwingStrength()
    {
        if (PlayerPrefs.GetInt("currency") > currentSwingUpgradeCost)
        {
            float currentSwingStrength = PlayerPrefs.GetFloat("swingStrength");
            PlayerPrefs.SetFloat("swingStrength", currentSwingStrength + 1.5f);
            PlayerPrefs.SetInt("NextSwingUpgrade", (currentSwingUpgradeCost + 100));
            PlayerPrefs.SetInt("currency", currency - currentSwingUpgradeCost);
            UpdateMenu();
        }
    }
}

