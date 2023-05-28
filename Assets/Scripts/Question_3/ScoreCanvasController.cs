using UnityEngine;
using TMPro;

public class ScoreCanvasController : MonoBehaviour
{
    public static ScoreCanvasController Instance;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (!Instance) Instance = this;
        else Destroy(this.gameObject);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score:- " + score;
    }
}
