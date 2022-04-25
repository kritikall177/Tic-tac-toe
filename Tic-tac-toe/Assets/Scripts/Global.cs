using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class Global : MonoBehaviour
{
    public static Sprite LastSprite { get; set; }
    private static BoxClick[] _allBoxes;
    
    public static void ResetGame()
    {
        foreach (var box in Global._allBoxes)
        {
            box.GetComponent<BoxClick>().mark = default;
            box.GetComponent<SpriteRenderer>().sprite = null;
            LastSprite = null;
            PrintText("");
        }
    }
    
    public static bool CheckMark()
    {
        int[,] arrOfCombinations = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
        for(var i = 0;i<arrOfCombinations.GetUpperBound(0) + 1; i++)
        {
            if (_allBoxes[arrOfCombinations[i, 0]].mark.Status == _allBoxes[arrOfCombinations[i, 1]].mark.Status !=
                _allBoxes[arrOfCombinations[i, 2]].mark.Status) continue;
            if(CheckWin(arrOfCombinations[i, 0], arrOfCombinations[i, 1], arrOfCombinations[i, 2])) return true;
        }

        return false;
    }

    public static bool IfStandoff()
    {
        if (_allBoxes.Any(box => box.mark.Status == false))
        {
            return false;
        }
        PrintText("Ничья");
        return true;
    }

    private static void PrintText(string str)
    {
        GameObject.FindGameObjectWithTag("Text").GetComponent<TextMeshProUGUI>().text = str;
    }

    private static bool CheckWin(int a, int b, int c)
    {
        char[] players = {'x','o' };
        foreach (var ch in players) if (_allBoxes[a].mark.TypeMark == ch && _allBoxes[b].mark.TypeMark == ch && _allBoxes[c].mark.TypeMark == ch)
        {
            PrintText($"{char.ToUpper(ch)} Победил!");
            return true;
        }
        return false;
    }
    public static void PauseGame()
    {
        for (byte i = 0; i < _allBoxes.Length; i++)
        {
            _allBoxes[i].mark.Status = true;
        }
    }

    private void Start()
    {
        _allBoxes = GameObject.Find("Board").GetComponentsInChildren<BoxClick>();
        _allBoxes = BoxClick.SetStartIndex(_allBoxes);
    }
}
