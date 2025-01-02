using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartNew() //loads game scene
    {
         //if (MenuUI.Instance.currentPlayer == null)
       // {
         //   MenuUI.Instance.playingPlayer.text = MenuUI.Instance.currentPlayer;
         //   SceneManager.LoadScene(1);
       // }
        //else
        {
            SceneManager.LoadScene(1);
        }
    }
    public void StartHigh() //loads high score screen
    {
        //if (MenuUI.Instance.currentPlayer == null)
       //{
           // MenuUI.Instance.playingPlayer.text = MenuUI.Instance.currentPlayer;
            //SceneManager.LoadScene(2);
       // }
        //else
        {
            SceneManager.LoadScene(2);
        }
    }
    public void StartMain() //loads main menu
    {
        SceneManager.LoadScene(0);
    }
}
