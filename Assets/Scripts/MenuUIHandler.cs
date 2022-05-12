using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TMP_InputField playerNameInput;
    // Start is called before the first frame update
    void Start()
    {
        string highScoreName = MainManager1.Instance.highScoreName;
        int highScore = MainManager1.Instance.highScore;
        if (highScoreName != "" && highScore > 0)
        {
            highScoreText.text = "High Score : " + highScoreName + " : " + highScore;
        }
    }

    // Update is called once per frame
    public void StartNew()
    {
        if (playerNameInput.text != "")
        {
            MainManager1.Instance.playerName = playerNameInput.text;
            SceneManager.LoadScene(1);
        }
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
