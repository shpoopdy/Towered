using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
  [SerializeField] int startingBalance = 150;

  [SerializeField] int currentBalance;

  [SerializeField] TextMeshProUGUI displayBalance;

  void Awake()
  {
    currentBalance = startingBalance;
    UpdateDisplay();
  }
  public int CurrentBalance { get { return currentBalance; } }
    
  public void Deposit(int amount)
  {
    currentBalance += Mathf.Abs(amount);
    UpdateDisplay();
  }

  public void Withdraw(int amount)
  {
    currentBalance -= Mathf.Abs(amount);
    UpdateDisplay();

    if (currentBalance < 0)
    {
      //Lose Game.
      ReloadScene();
    }
  }

  void UpdateDisplay()
  {
    displayBalance.text = "Gold: " + currentBalance;
  }

  void ReloadScene()
  {
    Scene currentScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(currentScene.buildIndex);
  }
}
