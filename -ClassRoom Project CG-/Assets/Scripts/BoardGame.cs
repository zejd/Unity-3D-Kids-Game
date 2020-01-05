using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class BoardGame : MonoBehaviour
{
    private string task;
    private List<char> lets;
    private List<string> cols;
    private Button red_B, blue_B, yellow_B, green_B, violet_B, orange_B, lblue_B, tquise_B, pink_B;
    private Hashtable numlet;
    private string dcolor;
    private string dletter;
    private Button B0, B1, B2, B3, B4, B5, B6, B7, B8;
    private AudioSource correct, wrong;
    private int wincount;
    private int level;
    private Button lvl1, lvl2, lvl3, lvl4, close, exit;
    private Text text;
    private Image iTarget;
    private Text tTarget;
    private Text score;
    private Canvas board;
    private Text response;
    private bool inmenu, islvl4;
    private Camera cam1;
    private Camera cam2;
    private float[] r = new float[9];
    private float[] g = new float[9];
    private float[] b = new float[9];

    private char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    private string[] colors = { "Red", "Blue", "Yellow", "Green", "Violet", "Orange", "LBlue", "Tquise", "Pink" };
    private string[] boje = { "Crvena", "Teget", "Zuta", "Zelena", "Lila", "Narandzasta", "Plava", "Tirkizna", "Roza" };
    void Start()
    {
        task = "Upari slovo i boju:\n";
        wincount = 0;
        level = 1;
        score = GameObject.FindGameObjectWithTag("word").GetComponent<Text>();
        board = GameObject.FindGameObjectWithTag("GameBoard").GetComponentInChildren<Canvas>();
        response = GameObject.FindGameObjectWithTag("Response").GetComponent<Text>();
        inmenu = false;
        cam1 = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cam2 = GameObject.FindGameObjectWithTag("GameBoardCam").GetComponent<Camera>();

        

        correct = GameObject.FindGameObjectWithTag("correctamundo").GetComponent<AudioSource>();
        wrong = GameObject.FindGameObjectWithTag("doh").GetComponent<AudioSource>();

        //Color Buttons

        red_B = GameObject.FindGameObjectWithTag("Red").GetComponent<Button>();
        blue_B = GameObject.FindGameObjectWithTag("Blue").GetComponent<Button>();
        yellow_B = GameObject.FindGameObjectWithTag("Yellow").GetComponent<Button>();
        green_B = GameObject.FindGameObjectWithTag("Green").GetComponent<Button>();
        violet_B = GameObject.FindGameObjectWithTag("Violet").GetComponent<Button>();
        orange_B = GameObject.FindGameObjectWithTag("Orange").GetComponent<Button>();
        pink_B = GameObject.FindGameObjectWithTag("Pink").GetComponent<Button>();
        lblue_B = GameObject.FindGameObjectWithTag("LBlue").GetComponent<Button>();
        tquise_B = GameObject.FindGameObjectWithTag("Tquise").GetComponent<Button>();

        for (int i = 0; i < 9; i++)
        {
            r[i] = GameObject.FindGameObjectWithTag(colors[i]).GetComponent<Image>().color.r;
            g[i] = GameObject.FindGameObjectWithTag(colors[i]).GetComponent<Image>().color.g;
            b[i] = GameObject.FindGameObjectWithTag(colors[i]).GetComponent<Image>().color.b;
        }

        //Letter Buttons

        B0 = GameObject.FindGameObjectWithTag("0").GetComponent<Button>();
        B1 = GameObject.FindGameObjectWithTag("1").GetComponent<Button>();
        B2 = GameObject.FindGameObjectWithTag("2").GetComponent<Button>();
        B3 = GameObject.FindGameObjectWithTag("3").GetComponent<Button>();
        B4 = GameObject.FindGameObjectWithTag("4").GetComponent<Button>();
        B5 = GameObject.FindGameObjectWithTag("5").GetComponent<Button>();
        B6 = GameObject.FindGameObjectWithTag("6").GetComponent<Button>();
        B7 = GameObject.FindGameObjectWithTag("7").GetComponent<Button>();
        B8 = GameObject.FindGameObjectWithTag("8").GetComponent<Button>();


        close = GameObject.FindGameObjectWithTag("close").GetComponent<Button>();

        //Designation of onClick() functions

        red_B.onClick.AddListener(R);
        blue_B.onClick.AddListener(B);
        yellow_B.onClick.AddListener(Y);
        green_B.onClick.AddListener(G);
        violet_B.onClick.AddListener(V);
        orange_B.onClick.AddListener(O);
        pink_B.onClick.AddListener(P);
        lblue_B.onClick.AddListener(L);
        tquise_B.onClick.AddListener(T);
        close.onClick.AddListener(GetMenu);
        B0.onClick.AddListener(L0);
        B1.onClick.AddListener(L1);
        B2.onClick.AddListener(L2);
        B3.onClick.AddListener(L3);
        B4.onClick.AddListener(L4);
        B5.onClick.AddListener(L5);
        B6.onClick.AddListener(L6);
        B7.onClick.AddListener(L7);
        B8.onClick.AddListener(L8);
    }

    public void GetMenu()
    {
        score.text = "0/3";
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
        lvl1 = GameObject.FindGameObjectWithTag("lvl1").GetComponent<Button>();
        lvl2 = GameObject.FindGameObjectWithTag("lvl2").GetComponent<Button>();
        lvl3 = GameObject.FindGameObjectWithTag("lvl3").GetComponent<Button>();
        lvl4 = GameObject.FindGameObjectWithTag("lvl4").GetComponent<Button>();
        exit = GameObject.FindGameObjectWithTag("exit").GetComponent<Button>();

        GameObject.FindGameObjectWithTag("3x3").GetComponent<Canvas>().enabled = true;
        GameObject.FindGameObjectWithTag("6x6").GetComponent<Canvas>().enabled = true;
        GameObject.FindGameObjectWithTag("9x9").GetComponent<Canvas>().enabled = true;
        for (int i = 0; i < 9; i++)
        {
            GameObject.FindGameObjectWithTag(colors[i]).GetComponent<Image>().color = new Color(r[i], g[i], b[i]);
        }
        GameObject.FindGameObjectWithTag("3x3").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("6x6").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("9x9").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("gamemenu").GetComponent<Canvas>().enabled = true;
        iTarget = null;
        tTarget = null;
        dcolor = null;
        dletter = null;
        response.text = " ";
        inmenu = true;
        lvl1.onClick.AddListener(lvl1_B);
        lvl2.onClick.AddListener(lvl2_B);
        lvl3.onClick.AddListener(lvl3_B);
        lvl4.onClick.AddListener(lvl4_B);
        exit.onClick.AddListener(closeButtonListener);

    }

    private void closeButtonListener()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
        cam1.gameObject.GetComponent<AudioListener>().enabled = true;
        cam2.gameObject.GetComponent<AudioListener>().enabled = false;
        board.enabled = true;
        cam2.enabled = false;
        cam1.enabled = true;
        inmenu = false;
        dcolor = null;
        dletter = null;
    }

    // Use this for initialization
    /// <summary>
    /// 
    /// </summary>
    /// <param name="wc"></param>
    /// <param name="pass"></param>
    public void StartGame1(int wc, bool pass)
    {
        if (pass && wc < 3)
        {
            inmenu = false;
            dcolor = null;
            dletter = null;
            islvl4 = false;
            task = "Upari slovo i boju:\n";

            score.text = wincount.ToString() + "/3";

            level = 1;
            wincount = wc;

            GameObject.FindGameObjectWithTag("3x3").GetComponent<Canvas>().enabled = true;
            GameObject.FindGameObjectWithTag("9x9").GetComponent<Canvas>().enabled = false;
            GameObject.FindGameObjectWithTag("6x6").GetComponent<Canvas>().enabled = false;
            GameObject.FindGameObjectWithTag("gamemenu").GetComponent<Canvas>().enabled = false;

            for (int i = 0; i < 3; i++)
            {
                GameObject.FindGameObjectWithTag(colors[i]).GetComponent<Image>().color = new Color(r[i], g[i], b[i]);
            }

            //Sounds


            //Main Game variables

            iTarget = null;
            tTarget = null;
            iTarget = GameObject.FindGameObjectWithTag("targetc").GetComponent<Image>();
            tTarget = GameObject.FindGameObjectWithTag("targetl").GetComponent<Text>();
            numlet = null;
            lets = new List<char>();
            cols = new List<string>();
            numlet = new Hashtable(3);

            // Adding colors to the list

            for (int i = 0; i < colors.Length; i++)
            {
                cols.Add(boje[i]);
            }

            //Taking 3 random letters from the List

            for (int element = 0; element < 3; element++)
            {
                int index = Random.Range(0, cols.Count - 1);
                numlet[element] = cols[element].ToString();
                //cols.RemoveAt(index);
                text = GameObject.FindGameObjectWithTag(element.ToString()).GetComponentInChildren<Text>();
                GameObject.FindGameObjectWithTag(colors[element]).GetComponentInChildren<Text>().text = " ";
                text.text = numlet[element].ToString();
            }

            //Adding letters to the List

            /* for (int i = 0; i < letters.Length; i++)
            {
                lets.Add(letters[i]);
            } */



            //Taking 3 random letters from the List

            /* for (int element = 0; element < 3; element++)
            {
                int index = Random.Range(0, lets.Count - 1);
                numlet[element] = lets[index].ToString();
                lets.RemoveAt(index);
                text = GameObject.FindGameObjectWithTag(element.ToString()).GetComponentInChildren<Text>();
                GameObject.FindGameObjectWithTag(colors[element]).GetComponentInChildren<Text>().text = " ";
                text.text = numlet[element].ToString();
            } */

            //Target color and letter

            //string targetl = numlet[Random.Range(0, numlet.Count)].ToString();
            int rn = Random.Range(0, 3);
            string targetl = boje[rn];
            string targetc = colors[rn];

            //Assigning Game Task

            GameObject.FindGameObjectWithTag("GameTask").GetComponent<Text>().text = task;
            iTarget.color = GameObject.FindGameObjectWithTag(targetc).GetComponent<Image>().color;
            tTarget.text = targetl;

        }
        else if (pass && wc < 9)
        {
            inmenu = false;
            dcolor = null;
            dletter = null;
            islvl4 = false;
            task = "Upari slovo i boju:\n";

            score.text = (wincount - 3).ToString() + "/6";

            wincount = wc;
            level = 2;

            GameObject.FindGameObjectWithTag("3x3").GetComponent<Canvas>().enabled = true;
            GameObject.FindGameObjectWithTag("9x9").GetComponent<Canvas>().enabled = false;
            GameObject.FindGameObjectWithTag("6x6").GetComponent<Canvas>().enabled = true;
            GameObject.FindGameObjectWithTag("gamemenu").GetComponent<Canvas>().enabled = false;

            for (int i = 0; i < 6; i++)
            {
                GameObject.FindGameObjectWithTag(colors[i]).GetComponent<Image>().color = new Color(r[i], g[i], b[i]);
            }

            //Main Game variables

            iTarget = null;
            tTarget = null;
            iTarget = GameObject.FindGameObjectWithTag("targetc").GetComponent<Image>();
            tTarget = GameObject.FindGameObjectWithTag("targetl").GetComponent<Text>();
            dcolor = null;
            dletter = null;
            lets = null;
            cols = null;
            numlet = null;
            lets = new List<char>();
            cols = new List<string>();
            numlet = new Hashtable(6);

            // Adding colors to the list

            for (int i = 0; i < colors.Length; i++)
            {
                cols.Add(boje[i]);
            }

            //Adding letters to the List

            /* for (int i = 0; i < letters.Length; i++)
            {
                lets.Add(letters[i]);
            } */

            //Taking 6 random letters from the List

            for (int element = 0; element < 6; element++)
            {
                int index = Random.Range(0, cols.Count - 1);
                numlet[element] = cols[element].ToString();
                //lets.RemoveAt(index);
                GameObject.FindGameObjectWithTag(element.ToString()).GetComponentInChildren<Text>().text = numlet[element].ToString();
                GameObject.FindGameObjectWithTag(colors[element]).GetComponentInChildren<Text>().text = " ";
            }

            //Target color and letter

            int rn = Random.Range(0, 6);
            string targetl = boje[rn];
            string targetc = colors[rn];

            //Assigning Game Task

            GameObject.FindGameObjectWithTag("GameTask").GetComponent<Text>().text = task;
            iTarget.color = GameObject.FindGameObjectWithTag(targetc).GetComponent<Image>().color;
            tTarget.text = targetl;

          
        }
        else if (pass & wc < 18)
        {
            wincount = wc;
            level = 3;
            inmenu = false;
            dcolor = null;
            dletter = null;
            islvl4 = false;
            task = "Upari slovo i boju:\n";

            score.text = (wincount - 9).ToString() + "/9";

            GameObject.FindGameObjectWithTag("3x3").GetComponent<Canvas>().enabled = true;
            GameObject.FindGameObjectWithTag("9x9").GetComponent<Canvas>().enabled = true;
            GameObject.FindGameObjectWithTag("6x6").GetComponent<Canvas>().enabled = true;
            GameObject.FindGameObjectWithTag("gamemenu").GetComponent<Canvas>().enabled = false;

            for (int i = 0; i < 9; i++)
            {
                GameObject.FindGameObjectWithTag(colors[i]).GetComponent<Image>().color = new Color(r[i], g[i], b[i]);
            }

            //Sounds

            correct = GameObject.FindGameObjectWithTag("correctamundo").GetComponent<AudioSource>();
            wrong = GameObject.FindGameObjectWithTag("doh").GetComponent<AudioSource>();

            //Main Game variables

            iTarget = null;
            tTarget = null;
            iTarget = GameObject.FindGameObjectWithTag("targetc").GetComponent<Image>();
            tTarget = GameObject.FindGameObjectWithTag("targetl").GetComponent<Text>();
            dcolor = null;
            dletter = null;
            lets = null;
            cols = null;
            numlet = null;
            lets = new List<char>();
            cols = new List<string>();
            numlet = new Hashtable(9);


            //Adding letters to the List

            // Adding colors to the list

            for (int i = 0; i < colors.Length; i++)
            {
                cols.Add(colors[i]);
            }

            /* for (int i = 0; i < letters.Length; i++)
            {
                lets.Add(letters[i]);
            } */

            //Taking 9 random letters from the List

            for (int element = 0; element < 9; element++)
            {
                //int index = Random.Range(0, lets.Count - 1);
                numlet[element] = cols[element].ToString();
                //lets.RemoveAt(index);
                GameObject.FindGameObjectWithTag(element.ToString()).GetComponentInChildren<Text>().text = numlet[element].ToString();
                GameObject.FindGameObjectWithTag(colors[element]).GetComponentInChildren<Text>().text = " ";
            }

            //Target color and letter

            int rn = Random.Range(0, 9);
            string targetl = colors[rn];
            string targetc = colors[rn];

            //Assigning Game Task

            GameObject.FindGameObjectWithTag("GameTask").GetComponent<Text>().text = task;
            iTarget.color = GameObject.FindGameObjectWithTag(targetc).GetComponent<Image>().color;
            tTarget.text = targetl;




        }
        else if (pass & wc < 30)
        {
            wincount = wc;
            level = 4;
            inmenu = false;
            dcolor = null;
            dletter = null;
            islvl4 = true;
            task = "Upari veliko i malo slovo:\n";


            score.text = (wincount - 18).ToString() + "/12";

            GameObject.FindGameObjectWithTag("3x3").GetComponent<Canvas>().enabled = true;
            GameObject.FindGameObjectWithTag("9x9").GetComponent<Canvas>().enabled = true;
            GameObject.FindGameObjectWithTag("6x6").GetComponent<Canvas>().enabled = true;
            GameObject.FindGameObjectWithTag("gamemenu").GetComponent<Canvas>().enabled = false;

            for (int i = 0; i < 9; i++)
            {
                GameObject.FindGameObjectWithTag(colors[i]).GetComponent<Image>().color = Color.white;
            }

            //Sounds

            correct = GameObject.FindGameObjectWithTag("correctamundo").GetComponent<AudioSource>();
            wrong = GameObject.FindGameObjectWithTag("doh").GetComponent<AudioSource>();

            //Main Game variables

            iTarget = null;
            tTarget = null;
            iTarget = GameObject.FindGameObjectWithTag("targetc").GetComponent<Image>();
            tTarget = GameObject.FindGameObjectWithTag("targetl").GetComponent<Text>();
            dcolor = null;
            dletter = null;
            lets = null;
            numlet = null;
            lets = new List<char>();
            numlet = new Hashtable(9);


            //Adding letters to the List

            for (int i = 0; i < letters.Length; i++)
            {
                lets.Add(letters[i]);
            }

            //Taking 6 random letters from the List

            for (int element = 0; element < 9; element++)
            {
                int index = Random.Range(0, lets.Count - 1);
                numlet[element] = lets[index].ToString();
                lets.RemoveAt(index);
                GameObject.FindGameObjectWithTag(element.ToString()).GetComponentInChildren<Text>().text = numlet[element].ToString();
                GameObject.FindGameObjectWithTag(colors[element]).GetComponentInChildren<Text>().text = numlet[element].ToString().ToLower();
            }

            //Target color and letter

            string targetl = numlet[Random.Range(0, numlet.Count)].ToString();
            string targetc = targetl.ToLower();

            //Assigning Game Task

            GameObject.FindGameObjectWithTag("GameTask").GetComponent<Text>().text = task;
            iTarget.color = Color.white;
            tTarget.text = targetl+" - "+targetc;




        }
        else if(wincount == 30){
            GetMenu();
        }
    }

    //Checks if our answer is correct
    bool CheckAnswer()
    {
        if (dcolor != null && dletter != null)
        {
            if (islvl4)
            {
                //if text and color of clicked buttons correspond to same attributes of target
                if (GameObject.FindGameObjectWithTag(dcolor).GetComponentInChildren<Text>().text == tTarget.text[4].ToString() && GameObject.FindGameObjectWithTag(dletter).GetComponentInChildren<Text>().text == tTarget.text[0].ToString())
                {
                    dcolor = null;
                    dletter = null;
                    response.text = "Correct!!!";
                    correct.Play();
                    wincount++;
                    return true;
                }
                else
                {
                    response.text = "Wrong!!";
                    dcolor = null;
                    dletter = null;
                    wrong.Play();
                    return false;
                }
            }
            else
            {
                //if text and color of clicked buttons correspond to same attributes of target
                if (GameObject.FindGameObjectWithTag(dcolor).GetComponent<Image>().color == iTarget.color && GameObject.FindGameObjectWithTag(dletter).GetComponentInChildren<Text>().text == tTarget.text)
                {
                    dcolor = null;
                    dletter = null;
                    response.text = "Correct!!!";
                    correct.Play();
                    wincount++;
                    return true;
                }
                else
                {
                    response.text = "Wrong!!";
                    dcolor = null;
                    dletter = null;
                    wrong.Play();
                    return false;
                }
            }
        }
        else
            return false;

    }



    //Set of functions that set determinants for our answer
    //Colors

    void R()
    {
        dcolor = "Red";
        response.text = " ";
        if(CheckAnswer())
            StartGame1(wincount, true);
    }
    void B()
    {
        dcolor = "Blue";
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }
    void Y()
    {
        dcolor = "Yellow";
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }
    void G()
    {
        dcolor = "Green";
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }
    void V()
    {
        dcolor = "Violet";
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }
    void O()
    {
        dcolor = "Orange";
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }
    void P()
    {
        dcolor = "Pink";
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }
    void L()
    {
        dcolor = "LBlue";
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }
    void T()
    {
        dcolor = "Tquise";
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }

    //Letters
    void L0()
    {
        dletter = B0.tag;
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }
    void L1()
    {
        dletter = B1.tag;
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }
    void L2()
    {
        dletter = B2.tag;
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }
    void L3()
    {
        dletter = B3.tag;
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }
    void L4()
    {
        dletter = B4.tag;
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }
    void L5()
    {
        dletter = B5.tag;
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }
    void L6()
    {
        dletter = B6.tag;
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }
    void L7()
    {
        dletter = B7.tag;
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }
    void L8()
    {
        dletter = B8.tag;
        response.text = " ";
        if (CheckAnswer())
            StartGame1(wincount, true);
    }

    void lvl1_B()
    {
        level = 1;
        score.text = "0/3";
        dcolor = null;
        dletter = null;
        StartGame1(0,true);
    }
    void lvl2_B()
    {
        level = 2;
        score.text = "0/6";
        dcolor = null;
        dletter = null;
        StartGame1(3,true);
    }
    void lvl3_B()
    {
        level = 3;
        score.text = "0/9";
        dcolor = null;
        dletter = null;
        StartGame1(9,true);
    }

    void lvl4_B()
    {
        level = 4;
        score.text = "0/12";
        dcolor = null;
        dletter = null;
        StartGame1(18, true);
    }

}
