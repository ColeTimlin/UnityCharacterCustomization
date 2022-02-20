using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;
using System;

public class Customization : MonoBehaviour
{
    public List<GameObject> Top;
    public List<GameObject> Middle;
    public List<GameObject> Bottom;
    public List<GameObject> Tone;
    public List<GameObject> Board;

    public GameObject currTop;
    public GameObject currMid;
    public GameObject currBot;
    public GameObject currTone;
    public GameObject currBoard;

    private int topIndex;
    private int midIndex;
    private int botIndex;
    private int toneIndex;
    private int boardIndex;

    private int topMax;
    private int midMax;
    private int botMax;
    private int toneMax;
    private int boardMax;

    public string fN = "save.THCUSTOMIZATION";

    public List<string> loads;

    private void Start()
    {
        topMax = Top.Count - 1;
        midMax = Middle.Count - 1;
        botMax = Bottom.Count - 1;
        toneMax = Tone.Count - 1;
        boardMax = Board.Count - 1;

        load();
    }

    public void back(string level)
    {
        if(level == "top")
        {
            if(currTop.name == Top[0].name)
            {
                currTop.SetActive(false);
                currTop = Top[topMax];
                topIndex = topMax;
                currTop.SetActive(true);
            }
            else
            {
                currTop.SetActive(false);
                currTop = Top[topIndex - 1];
                topIndex--;
                currTop.SetActive(true);
            }
        }

        if (level == "mid")
        {
            if (currMid.name == Middle[0].name)
            {
                currMid.SetActive(false);
                currMid = Middle[midMax];
                midIndex = midMax;
                currMid.SetActive(true);
            }
            else
            {
                currMid.SetActive(false);
                currMid = Middle[midIndex - 1];
                midIndex--;
                currMid.SetActive(true);
            }
        }

        if (level == "bot")
        {
            if (currBot.name == Bottom[0].name)
            {
                currBot.SetActive(false);
                currBot = Bottom[botMax];
                botIndex = botMax;
                currBot.SetActive(true);
            }
            else
            {
                currBot.SetActive(false);
                currBot = Bottom[botIndex - 1];
                botIndex--;
                currBot.SetActive(true);
            }
        }

        if (level == "tone")
        {
            if (currTone.name == Tone[0].name)
            {
                currTone.SetActive(false);
                currTone = Tone[toneMax];
                toneIndex = toneMax;
                currTone.SetActive(true);
            }
            else
            {
                currTone.SetActive(false);
                currTone = Tone[toneIndex - 1];
                toneIndex--;
                currTone.SetActive(true);
            }
        }

        if (level == "board")
        {
            if (currBoard.name == Board[0].name)
            {
                currBoard.SetActive(false);
                currBoard = Board[boardMax];
                boardIndex = boardMax;
                currBoard.SetActive(true);
            }
            else
            {
                currBoard.SetActive(false);
                currBoard = Board[boardIndex - 1];
                boardIndex--;
                currBoard.SetActive(true);
            }
        }
    }

    public void forward(string level)
    {
        if (level == "top")
        {
            if (currTop.name != Top[topMax].name)
            {
                currTop.SetActive(false);
                currTop = Top[topIndex + 1];
                topIndex++;
                currTop.SetActive(true);
            }
            else
            {
                currTop.SetActive(false);
                currTop = Top[0];
                topIndex = 0;
                currTop.SetActive(true);
            }
        }

        if (level == "mid")
        {
            if (currMid.name != Middle[midMax].name)
            {
                currMid.SetActive(false);
                currMid = Middle[midIndex + 1];
                midIndex++;
                currMid.SetActive(true);
            }
            else
            {
                currMid.SetActive(false);
                currMid = Middle[0];
                midIndex = 0;
                currMid.SetActive(true);
            }
        }

        if (level == "bot")
        {
            if (currBot.name != Bottom[botMax].name)
            {
                currBot.SetActive(false);
                currBot = Bottom[botIndex + 1];
                botIndex++;
                currBot.SetActive(true);
            }
            else
            {
                currBot.SetActive(false);
                currBot = Bottom[0];
                botIndex = 0;
                currBot.SetActive(true);
            }
        }

        if (level == "tone")
        {
            if (currTone.name != Tone[toneMax].name)
            {
                currTone.SetActive(false);
                currTone = Tone[toneIndex + 1];
                toneIndex++;
                currTone.SetActive(true);
            }
            else
            {
                currTone.SetActive(false);
                currTone = Tone[0];
                toneIndex = 0;
                currTone.SetActive(true);
            }
        }

        if (level == "board")
        {
            if (currBoard.name != Board[boardMax].name)
            {
                currBoard.SetActive(false);
                currBoard = Board[boardIndex + 1];
                boardIndex++;
                currBoard.SetActive(true);
            }
            else
            {
                currBoard.SetActive(false);
                currBoard = Board[0];
                boardIndex = 0;
                currBoard.SetActive(true);
            }
        }
    }

    public void clear()
    {
        currBot.SetActive(false);
        currMid.SetActive(false);
        currTop.SetActive(false);
        currTone.SetActive(false);
        currBoard.SetActive(false);

        currTone = Tone[0];
        currBot = Bottom[0];
        currMid = Middle[0];
        currTop = Top[0];
        currBoard = Board[0];

        toneIndex = 0;
        botIndex = 0;
        midIndex = 0;
        topIndex = 0;
        boardIndex = 0;

        currTone.SetActive(true);
        currBot.SetActive(true);
        currMid.SetActive(true);
        currTop.SetActive(true);
        currBoard.SetActive(true);
    }

    public void apply()
    {
        File.WriteAllText(fN, topIndex + "\n" + midIndex + "\n" + botIndex + "\n" + toneIndex + "\n" + boardIndex);
    }

    public void load()
    {
        var scanned = File.ReadAllText(fN);
        loads = new List<string>(
            scanned.Split(new string[] { "\n" }, StringSplitOptions.None));


        int loadedTop = Convert.ToInt32(loads[0]);
        int loadedMid = Convert.ToInt32(loads[1]);
        int loadedBot = Convert.ToInt32(loads[2]);
        int loadedTone = Convert.ToInt32(loads[3]);
        int loadedBoard = Convert.ToInt32(loads[4]);

        currTop = Top[loadedTop];
        currMid = Middle[loadedMid];
        currBot = Bottom[loadedBot];
        currTone = Tone[loadedTone];
        currBoard = Board[loadedBoard];

        currTop.SetActive(true);
        currMid.SetActive(true);
        currBot.SetActive(true);
        currTone.SetActive(true);
        currBoard.SetActive(true);
    }
}
