using TMPro;
using UnityEngine;


public class ScoreScript : MonoBehaviour
{
    public int topScore;
    public int secondScore;
    public int thirdScore;
    public string topName;
    public string secondName;
    public string thirdName;

    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI SecondScore;
    public TextMeshProUGUI ThirdScore;

    public void Start()
    {
        topScore = MenuUI.Instance.highScore;
        secondScore = MenuUI.Instance.secondScore;
        thirdScore = MenuUI.Instance.thirdScore;

        HighScore.text = $"Top Score : {MenuUI.Instance.topName} : {MenuUI.Instance.highScore}";
        SecondScore.text = $"Second : {MenuUI.Instance.secondName} : {MenuUI.Instance.secondScore}";
        ThirdScore.text = $"Third : {MenuUI.Instance.thirdName} : {MenuUI.Instance.thirdScore}";
    }

}
