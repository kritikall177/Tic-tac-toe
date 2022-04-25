using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClick : MonoBehaviour
{
    public struct BoxStatus
    {
        public bool Status { get; set; }
        public char TypeMark { get; set; }
    }

    public Sprite SpriteX;
    public Sprite SpriteO;
    public BoxStatus mark;
    private byte _index;

    public static BoxClick[] SetStartIndex(BoxClick[] allBoxes)
    {
        for (byte i = 0; i < allBoxes.Length; i++)
        {
            allBoxes[i]._index = i;
        }

        return allBoxes;
    }
    
    public void OnMouseDown()
    {
        if (mark.Status) return;
        if (Global.LastSprite == SpriteX)
        {
            GetComponent<SpriteRenderer>().sprite = SpriteO;
            Global.LastSprite = SpriteO;
            mark.TypeMark = 'o';
        }
        else if (Global.LastSprite == SpriteO | Global.LastSprite == null)
        {
            GetComponent<SpriteRenderer>().sprite = SpriteX;
            Global.LastSprite = SpriteX;
            mark.TypeMark = 'x';
        }
        mark.Status = true;
        if(Global.CheckMark() || Global.IfStandoff()) Global.PauseGame();
    }
}
