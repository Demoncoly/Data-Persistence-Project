using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text HighScore;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    public int m_Points;
    
    public bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }

        HighScore.text = $"Top Score : {MenuUI.Instance.topName} : {MenuUI.Instance.highScore}";
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
        MenuUI.Instance.currentScore = m_Points;


    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        if (m_Points > MenuUI.Instance.highScore)
        {
            MenuUI.Instance.thirdScore = MenuUI.Instance.secondScore;
            MenuUI.Instance.thirdName = MenuUI.Instance.secondName;
            MenuUI.Instance.secondName = MenuUI.Instance.topName;
            MenuUI.Instance.secondScore = MenuUI.Instance.highScore;
            MenuUI.Instance.highScore = MenuUI.Instance.currentScore;
            MenuUI.Instance.topName = MenuUI.Instance.currentPlayer;
        }
        else if (m_Points > MenuUI.Instance.secondScore)
        {
            MenuUI.Instance.thirdScore = MenuUI.Instance.secondScore;
            MenuUI.Instance.thirdName = MenuUI.Instance.secondName;
            MenuUI.Instance.secondScore = MenuUI.Instance.currentScore;
            MenuUI.Instance.secondName = MenuUI.Instance.currentPlayer;
        }
        else if (m_Points > MenuUI.Instance.thirdScore)
        {
            MenuUI.Instance.thirdScore = MenuUI.Instance.currentScore;
            MenuUI.Instance.thirdName = MenuUI.Instance.currentPlayer;
        }
        MenuUI.Instance.SaveScore();
    }
    
}
