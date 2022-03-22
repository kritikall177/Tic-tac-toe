using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Global : MonoBehaviour
{
    public static Sprite lastSprite = null;
    public static BoxClick[] allBoxes;
    
    public static bool CheckMark()
    {
        int[,] arrOfCombinations = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
        for(int i = 0;i<arrOfCombinations.GetUpperBound(0) + 1; i++)
        {
            if (allBoxes[arrOfCombinations[i,0]].mark.Status == allBoxes[arrOfCombinations[i, 1]].mark.Status == allBoxes[arrOfCombinations[i, 2]].mark.Status) if(CheckWin(arrOfCombinations[i, 0], arrOfCombinations[i, 1], arrOfCombinations[i, 2])) return true;
        }

        return false;
    }

    public static bool IfStandoff()
    {
        foreach(var box in allBoxes) if (box.mark.Status == false) return false;
        PrintText("Ничья");
        return true;
    }

    public static void PrintText(string str)
    {
        GameObject.FindGameObjectWithTag("Text").GetComponent<TextMeshProUGUI>().text = str;
    }

    public static bool CheckWin(int a, int b, int c)
    {
        char[] players = {'x','o' };
        foreach (var ch in players) if (allBoxes[a].mark.TypeMark == ch && allBoxes[b].mark.TypeMark == ch && allBoxes[c].mark.TypeMark == ch)
            {
                PrintText($"{char.ToUpper(ch)} Победил!");
                return true;
            }
        return false;
    }
    public static void PauseGame()
    {
        for (byte i = 0; i < allBoxes.Length; i++)
        {
            allBoxes[i].mark.Status = true;
        }
    }
    void Start()
    {
        allBoxes = GameObject.Find("Board").GetComponentsInChildren<BoxClick>();
        for (byte i = 0; i < allBoxes.Length; i++)
        {
            allBoxes[i].Index = i;
        }

    }
}
