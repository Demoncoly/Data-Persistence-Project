using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;



public class MenuUI : MonoBehaviour
{
    public static MenuUI Instance;
    //all the score int's and player names condensed for readability.
    public int highScore; public int secondScore; public int thirdScore; public string topName; public string secondName; public string thirdName;
    public string currentPlayer; //for saving purposes

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
    public void ReadStringInput(string playerName)
    {
        currentPlayer = playerName;
        Debug.Log(currentPlayer);
    }
    [System.Serializable]
    class SaveData
    {
        //all the variables top score 1,2,3 & playername 1,2,3
        public int highScore; public int secondScore; public int thirdScore; public string topName; public string secondName; public string thirdName;
    }
    public void SaveScore()
    {
    SaveData[] data = new SaveData[6];
        //all the variables top score 1,2,3 & playername 1,2,3
        data[0].highScore = highScore; data[1].secondScore = secondScore; data[2].thirdScore = thirdScore; data[3].topName = topName; data[4].secondName = secondName; data[5].thirdName = thirdName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData[] data = JsonUtility.FromJson<SaveData[]>(json);

            //all the variables top score 1,2,3 & playername 1,2,3 condensed to one line for readability.
            highScore = data[0].highScore; secondScore = data[1].secondScore; thirdScore = data[2].thirdScore; topName = data[3].topName; secondName = data[4].secondName; thirdName = data[5].thirdName;
        }
    }

}
