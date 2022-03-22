using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public void TaskOnClick()
    {
        foreach (var box in Global.allBoxes)
        {
            box.GetComponent<BoxClick>().mark = default;
            box.GetComponent<SpriteRenderer>().sprite = null;
            Global.lastSprite = null;
            Global.PrintText("");
        }
    }
}
