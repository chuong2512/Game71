using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : RObo.Singleton<Check>
{
    public int soi, cuu;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Soi"))
        {
            soi++;
        }

        if (other.gameObject.CompareTag("Cuu"))
        {
            cuu++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Soi"))
        {
            soi--;
        }
    }

    public void CheckFirst()
    {
        if (soi <= 0)
        {
            TheGameUI.Instance.ShowWin();
        }
    }

    public void Check1()
    {
        if (soi <= 0)
        {
            TheGameUI.Instance.ShowWin();
        }
        else
        {
            TheGameUI.Instance.ShowLose();
        }
    }
}