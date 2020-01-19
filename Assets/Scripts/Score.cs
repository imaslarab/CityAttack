using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    public float startTime;
    public int currentScore;

    private void Start()
    {
        startTime = Time.time;
        currentScore = 0;
    }

    public void AddPoints(int points) {
        currentScore += points;
    }

    public void SetTime() {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = ((int) (t % 60)).ToString();
        timeText.text = minutes + ":" + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        SetTime();
        scoreText.text = "Score: " + currentScore;
    }
}
