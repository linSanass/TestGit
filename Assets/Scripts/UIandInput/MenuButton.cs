using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void EnterGameScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void EnterGameSceneRe()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
        PlayerGetHit.playerIsRecover = true;
    }

    public void EnterBeginScene()
    {
        SceneManager.LoadScene("BeginScene");
    }

    public void ExitGame()
    {
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//�༭״̬���˳�
#else
        Application.Quit();//���������˳�
#endif
        }
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
    }
}
