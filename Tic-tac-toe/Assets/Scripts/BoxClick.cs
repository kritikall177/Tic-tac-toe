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
    public byte index;
    public BoxStatus mark;

    public void OnMouseDown()
    {
        if(!mark.Status)
        {
            if (Global.lastSprite == SpriteX)
            {
                GetComponent<SpriteRenderer>().sprite = SpriteO;
                Global.lastSprite = SpriteO;
                mark.TypeMark = 'o';
            }
            else if (Global.lastSprite == SpriteO | Global.lastSprite == null)
            {
                GetComponent<SpriteRenderer>().sprite = SpriteX;
                Global.lastSprite = SpriteX;
                mark.TypeMark = 'x';
            }
            mark.Status = true;
            if(Global.CheckMark() || Global.IfStandoff()) Global.PauseGame();
        }
    }
}
