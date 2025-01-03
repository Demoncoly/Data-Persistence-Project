using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    public string namePlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartNew() //loads game scene
    {
        {
            SceneManager.LoadScene(1);
        }
    }
    public void StartHigh() //loads high score screen
    {
        {
            SceneManager.LoadScene(2);
        }
    }
    public void StartMain() //loads main menu
    {
        SceneManager.LoadScene(0);
    }
    public void CommenceExit()
    {
        MenuUI.Instance.Exit();
    }
    public void ResetScores()
    {
        MenuUI.Instance.highScore = 0;
        MenuUI.Instance.secondScore = 0;
        MenuUI.Instance.thirdScore = 0;
        MenuUI.Instance.topName = "Your name here";
        MenuUI.Instance.secondName = "Your name here";
        MenuUI.Instance.thirdName = "Your name here";
        MenuUI.Instance.SaveScore();
        MenuUI.Instance.ResetHighScore();
    }
    public void ReadStringInput(string playerName)
    {
        namePlayer = playerName;
        Debug.Log(namePlayer);
        MenuUI.Instance.currentPlayer = namePlayer;
    }
}
