using System.IO;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using TMPro;
#endif


[DefaultExecutionOrder(1000)]
public class MenuUI : MonoBehaviour
{
    public static MenuUI Instance;
    //all the score int's and player names condensed for readability.
    public int highScore; public int secondScore; public int thirdScore; public string topName; public string secondName; public string thirdName;
    public int currentScore;
    public string currentPlayer; //for saving purposes
    public TMP_Text topScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }
    public void Start()
    {
        LoadScore();
    }
    
    public void ResetHighScore()
    {
        topScore = GameObject.Find("Top Score").GetComponent<TMP_Text>();
        topScore.text = $"Top Score: Reset";
    }
    [System.Serializable]
    class SaveData
    {
        //all the variables top score 1,2,3 & playername 1,2,3
        public int highScore; public int secondScore; public int thirdScore; public string topName; public string secondName; public string thirdName;
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        //all the variables top score 1,2,3 & playername 1,2,3
        data.highScore = highScore; data.secondScore = secondScore; data.thirdScore = thirdScore; data.topName = topName; data.secondName = secondName; data.thirdName = thirdName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            //all the variables top score 1,2,3 & playername 1,2,3 condensed to one line for readability.
            highScore = data.highScore; secondScore = data.secondScore; thirdScore = data.thirdScore; topName = data.topName; secondName = data.secondName; thirdName = data.thirdName;
        Debug.Log (data);
        } else
        {
            Debug.Log("file not found");
        }
    }
    public void Exit()
    {
        SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
