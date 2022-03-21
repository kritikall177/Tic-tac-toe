using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClick : MonoBehaviour
{
    public struct Mark
    {
        public bool status { get; set; }
        public char typeMark { get; set; }
    }

    public Sprite noneSprite;
    public Sprite spriteX;
    public Sprite spriteO;
    public Mark mark;
    public byte index;

    public void OnMouseDown()
    {
        if (mark.status == true);
        else
        {
            Debug.Log("Поинт");
            if (Global.lastSprite == spriteX)
            {
                GetComponent<SpriteRenderer>().sprite = spriteO;
                Global.lastSprite = spriteO;
                mark.typeMark = 'o';
            }
            else if (Global.lastSprite == spriteO | Global.lastSprite == null)
            {
                GetComponent<SpriteRenderer>().sprite = spriteX;
                Global.lastSprite = spriteX;
                mark.typeMark = 'x';
            }
            mark.status = true;
            if(Global.CheckMark() | Global.IfStandoff()) Global.PauseGame();
        }
    }
    void Start()
    {
    }

    void Update()
    {
    }
}
