using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Global : MonoBehaviour
{
    public static Sprite lastSprite = null;
    public static GameObject[] allBoxes;
    public static GameObject matchResult;
    
    public static bool CheckMark()
    {
        int[,] arr = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 }, };
        for(int i = 0;i<arr.GetUpperBound(0) + 1; i++)
        {
            if (allBoxes[arr[i,0]].GetComponent<BoxClick>().mark.status == allBoxes[arr[i, 1]].GetComponent<BoxClick>().mark.status == allBoxes[arr[i, 2]].GetComponent<BoxClick>().mark.status) if(CheckWin(arr[i, 0], arr[i, 1], arr[i, 2])) return true;
        }

        return false;
    }

    public static bool IfStandoff()
    {
        foreach(var box in allBoxes) if (box.GetComponent<BoxClick>().mark.status == false) return false;
        Print("Ничья");
        return true;
    }

    public static void Print(string str)//вывести в отдельный скрипт на самом тексте
    {
        matchResult.GetComponent<TextMeshProUGUI>().text = str;
    }

    public static bool CheckWin(int a, int b, int c)
    {
        char[] players = {'x','o' };
        foreach (var ch in players) if (allBoxes[a].GetComponent<BoxClick>().mark.typeMark == ch && allBoxes[b].GetComponent<BoxClick>().mark.typeMark == ch && allBoxes[c].GetComponent<BoxClick>().mark.typeMark == ch)
            {
                Print($"{char.ToUpper(ch)} Победил!");
                return true;
            }
        return false;
    }
    public static void PauseGame()
    {
        for (byte i = 0; i < allBoxes.Length; i++)
        {
            allBoxes[i].GetComponent<BoxClick>().mark.status = true;

        }
    }
    public static void NewGame()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        allBoxes = GameObject.FindGameObjectsWithTag("Box");
        matchResult = GameObject.FindGameObjectWithTag("Text");
        for (byte i = 0;i < allBoxes.Length;i++)
        {
            allBoxes[i].GetComponent<BoxClick>().index = i;

        }

    }
}
