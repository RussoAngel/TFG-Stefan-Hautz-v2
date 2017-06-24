using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;
    public Text theText;
    public TextAsset textFile;
    public string[] textLines;
    public GameObject IngredientsPanel;
    public Slider eggs;
    public Text eggText;
    public Slider butter;
    public Text butterText;
    public Slider flour;
    public Text flourText;
    public Slider milk;
    public Text milkText;
    public Slider sugar;
    public Text sugarText;
    public Slider orange;
    public Text orangeText;
    public Slider spoon;
    public Text spoonText;
    public int currentLine;
    public int endLine;
    public Animator yure;
    public Animator yera;
    public Animator kitchen;
    public GameObject panelIngredientes;
    public GameObject scorePanel;
    public GameObject objectivePanel;
    public Text score;
    public GameObject comprobar;

    private String eggvalue;
    private String buttervalue;
    private String flourvalue;
    private String milkvalue;
    private String orangevalue;
    private String sugarvalue;
    private String spoonvalue;
    private int totalFails;
    private float totalTime;
    private float startTime;


    // Use this for initialization
    void Start()
    {
        // IngredientsPanel.SetActive(false);
        //centesimaE.text = centesimaEg.ToString();
        if (textFile != null)
        {
            textLines = textFile.text.Split('\n');
        }

        if (endLine == 0) endLine = textLines.Length - 1;
        panelIngredientes.SetActive(false);
        objectivePanel.SetActive(false);
        scorePanel.SetActive(false);
        comprobar.SetActive(false);
        startTime = Time.time;
    }


    void Update()
    {
        //eggsText.text = eggs.value.ToString("0.00");
        textManager();
        showValues();
    }

    private void checkSuccess()
    {
        if (eggvalue.Equals("3.00") && buttervalue.Equals("180") && flourvalue.Equals("2.25") && milkvalue.Equals("0.75")
            && sugarvalue.Equals("1.50") && orangevalue.Equals("1.50") && spoonvalue.Equals("2.25"))
        {
            kitchen.SetBool("recetaLista", true);
            objectivePanel.SetActive(false);
            panelIngredientes.SetActive(false);
            comprobar.SetActive(false);
            scorePanel.SetActive(true);
            totalTime = Time.time - startTime;
            score.text= ("Tiempo total: " + String.Format("{0:0.00}", totalTime) + "\n" + "Fallos totales: " + totalFails);
            Debug.Log(totalTime);
            Debug.Log(totalFails);
            Debug.Log(score.text);

        }
        else {
            totalFails++;
        }
    }

    private void showValues()
    {
        eggvalue = String.Format("{0:0.00}", eggs.value);
        eggText.text = eggvalue;
        buttervalue = butter.value.ToString();
        butterText.text = buttervalue;
        flourvalue = String.Format("{0:0.00}", flour.value);
        flourText.text = flourvalue;
        milkvalue = String.Format("{0:0.00}", milk.value);
        milkText.text = milkvalue;
        sugarvalue = String.Format("{0:0.00}", sugar.value);
        sugarText.text = sugarvalue;
        orangevalue = String.Format("{0:0.00}", orange.value);
        orangeText.text = orangevalue;
        spoonvalue = String.Format("{0:0.00}", spoon.value);
        spoonText.text = spoonvalue;

    }

    public void nextLevel(string name)
    {
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(name);
    }

    void textManager()
    {
        if (currentLine > endLine)
        {
            yure.SetBool("hablando", false);
            yera.SetBool("hablando", false);
            panelIngredientes.SetActive(true);
            objectivePanel.SetActive(true);
            textBox.SetActive(false);
            comprobar.SetActive(true);
            return;

        }
            theText.text = textLines[currentLine];
        if (theText.text.Length >= 4)
        {
            if (theText.text.Substring(0, 4).Equals("Yure"))
            {
                yure.SetBool("hablando", true);
                yera.SetBool("hablando", false);
            }
            if (theText.text.Substring(0, 4).Equals("Yera"))
            {
                yure.SetBool("hablando", false);
                yera.SetBool("hablando", true);
            }
        }

            if (Input.GetKeyDown(KeyCode.Return)) currentLine += 1;
        }
}
