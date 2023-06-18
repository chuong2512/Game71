using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RObo;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum State
{
    Drawing,
    Stop,
    Pause
}

public class TheGameUI : Singleton<TheGameUI>
{
    public GameObject lose, win;

    public State currentState = State.Drawing;


    public TextMeshProUGUI levelTMP;
    public TextMeshProUGUI Count;

    // Start is called before the first frame update
    void Start()
    {
        SetState(State.Drawing);

        levelTMP.SetText($"LEVEL {GameDataManager.Instance.playerData.level}");
    }

    public void ShowLose()
    {
        IEnumerator CheckIE()
        {
            yield return new WaitForSeconds(3);
            StopAllCoroutines();
            SetState(State.Pause);
            lose.SetActive(true);
        }

        StartCoroutine(CheckIE());
    }

    public void ShowWin()
    {
        IEnumerator CheckIE()
        {
            yield return new WaitForSeconds(3);
            StopAllCoroutines();
            SetState(State.Pause);
            win.SetActive(true);
        }

        StartCoroutine(CheckIE());
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void NextGame()
    {
        if (GameDataManager.Instance.playerData.SubDiamond(1))
        {
            NextGameWin();
        }
    }

    public void NextGameWin()
    {
        GameDataManager.Instance.playerData.UpLevel();
        SceneManager.LoadScene("Game");
    }

    [Button]
    public void Jump()
    {
        SetState(State.Drawing);
    }

    private float duration = 1f;

    public void SetState(State state)
    {
        currentState = state;
    }

    public void Check1()
    {
        IEnumerator CheckIE()
        {
            yield return new WaitForSeconds(2);
            Check.Instance.Check1();
        }

        StartCoroutine(CheckIE());
    }

    public void CheckFirst()
    {
        IEnumerator CheckIE()
        {
            yield return new WaitForSeconds(2);
            Check.Instance.CheckFirst();
        }

        StartCoroutine(CheckIE());
    }
}