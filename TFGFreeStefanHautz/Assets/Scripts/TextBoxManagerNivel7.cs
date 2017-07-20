using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public class TextBoxManagerNivel7 : MonoBehaviour
{

    public Text theText, score, lin1, lin2, lin3, lin4;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine, endLine;
    public Animator yure, yera, kitchen;
    public GameObject scorePanel, objectivePanel, scrollPanel, comprobar, tablaDrag, cas1, cas2, cas3, textBox, 
        cas4, cas5, cas6, yureQuestion, yeraQuestion, yureSprite, yeraSprite, panelRespuesta1, panelRespuesta2, moneyPileSprite, star1, star2, star3, panelLevel, leaveButt, changeLevelButt;
    public AudioSource sound;
    public Button mute;

    private int totalFails, solu1 = 0, solu2 = 0, solu3 = 0, solu4 = 0;
    private float totalTime, startTime;
    private bool status = false, debesEntrar = true, cooldownAnswer = false, valid1 = false, valid2 = false;
    private Button comprobarButt;
    private String contenidoCas1 = "", contenidoCas2 = "", nombre;

    void Start()
    {
        if (textFile != null)
        {
            textLines = textFile.text.Split('\n');
        }

        if (endLine == 0) endLine = textLines.Length - 1;

        objectivePanel.SetActive(status);
        scrollPanel.SetActive(status);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        panelLevel.SetActive(false);
        scorePanel.SetActive(status);
        comprobar.SetActive(status);
        tablaDrag.SetActive(status);
        startTime = Time.time;
        moneyPileSprite.SetActive(false);
        yureQuestion.SetActive(false);
        yeraQuestion.SetActive(false);
        PlayerPrefs.SetString("savedLevel", SceneManager.GetActiveScene().name);
        nombre = PlayerPrefs.GetString("playerName").Split(' ').First();
    }

    public void increaseSolu()
    {
        if (solu1 < 99) solu1++;
    }

    public void decreaseSolu()
    {
        if (solu1 > 0) solu1--;
    }

    public void increaseSolu2()
    {
        if (solu2 < 99) solu2++;
    }

    public void decreaseSolu2()
    {
        if (solu2 > 0) solu2--;
    }

    public void increaseSolu3()
    {
        if (solu3 < 99) solu3++;
    }

    public void decreaseSolu3()
    {
        if (solu3 > 0) solu3--;
    }

    public void increaseSolu4()
    {
        if (solu4 < 99) solu4++;
    }

    public void decreaseSolu4()
    {
        if (solu4 > 0) solu4--;
    }

    void resetCooldown()
    {
        cooldownAnswer = false;
        comprobarButt.interactable = true;
    }

    public void triggerMute()
    {
        if (mute.GetComponentInChildren<Text>().text.Equals("Quitar sonido"))
        {
            mute.GetComponentInChildren<Text>().text = "Poner Sonido";
            mute.GetComponent<Image>().color = new Color32(0x5B, 0xC6, 0xFB, 0xFF);
            sound.mute = true;
        }
        else
        {
            mute.GetComponentInChildren<Text>().text = "Quitar sonido";
            mute.GetComponent<Image>().color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            sound.mute = false;
        }
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }

    public void openSelector()
    {
        panelLevel.SetActive(true);
    }

    public void closeSelector()
    {
        panelLevel.SetActive(false);
    }

    void Update()
    {

        if (debesEntrar == true)
        {
            textManager();
        }

        if (!cas1.transform.childCount.Equals(0) && !cas2.transform.childCount.Equals(0) && !cas3.transform.childCount.Equals(0))
        {
            contenidoCas1 = cas1.transform.GetChild(0).name + cas2.transform.GetChild(0).name + cas3.transform.GetChild(0).name;
        }
        else
        {
            contenidoCas1 = "";
        }

        if (!cas4.transform.childCount.Equals(0) && !cas5.transform.childCount.Equals(0) && !cas6.transform.childCount.Equals(0))
        {
            contenidoCas2 = cas4.transform.GetChild(0).name + cas5.transform.GetChild(0).name + cas6.transform.GetChild(0).name;
        }
        else
        {
            contenidoCas2 = "";
        }

        if (contenidoCas1.Equals("40-30"))
        {
            valid1 = true;
        }
        else
        {
            valid1 = false;
        }

        if (contenidoCas2.Equals("10/10"))
        {
            valid2 = true;
        }
        else
        {
            valid2 = false;
        }

        lin1.text = "10·X= "+ solu1;
        lin2.text = "X= "+ solu2;
        lin3.text = "30+10· " + solu3 + "\t\t =40";
        lin4.text = solu4 + " =40";

    }

    public void Quit()
    {
        Application.Quit();
    }

    void OnGUI()
    {
        tablaDrag.SetActive(status);
        comprobar.SetActive(status);
        objectivePanel.SetActive(status);
        scrollPanel.SetActive(status);
    }

    public void checkSuccess()
    {
        if (valid1 && valid2 && solu1.Equals(10) &&
            solu2.Equals(1) && solu3.Equals(1) && solu4.Equals(40) && !cooldownAnswer)
        {
            status = false;
            scorePanel.SetActive(true);
            changeLevelButt.SetActive(false);
            leaveButt.SetActive(false);
            totalTime = Time.time - startTime;
            score.text = ("¡Has acertado!\n\nTiempo total: " + String.Format("{0:0.00}", totalTime) + "\n\nFallos totales: " + totalFails);
            PlayerPrefs.SetInt("failsLevel7", totalFails);
            PlayerPrefs.SetFloat("timeLevel7", totalTime);
            switch (totalFails)
            {
                case 0:
                    star3.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel7", 3);
                    break;
                case 1:
                    star2.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel7", 2);
                    break;
                case 2:
                    star1.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel7", 1);
                    break;
                default:
                    break;
            }
            moneyPileSprite.SetActive(true);
            yureQuestion.SetActive(false);
            yeraQuestion.SetActive(false);
            yureSprite.SetActive(true);
            yeraSprite.SetActive(true);
        }
        else
        {
            if (!cooldownAnswer)
            {
                totalFails++;
                Invoke("resetCooldown", 5.0f);
                cooldownAnswer = true;
                comprobarButt = comprobar.GetComponent<Button>();
                comprobarButt.interactable = false;
            }
            if (!valid1) panelRespuesta1.GetComponent<Image>().color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (valid1) panelRespuesta1.GetComponent<Image>().color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!valid2) panelRespuesta2.GetComponent<Image>().color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (valid2) panelRespuesta2.GetComponent<Image>().color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (solu1.Equals(10)) lin1.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!solu1.Equals(10)) lin1.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (solu2.Equals(1)) lin2.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!solu2.Equals(1)) lin2.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (solu3.Equals(1)) lin3.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!solu3.Equals(1)) lin3.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (solu4.Equals(40)) lin4.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!solu4.Equals(40)) lin4.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
        }
    }

    public void nextLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    void textManager()
    {
        if (currentLine > endLine)
        {
            yure.SetBool("hablando", false);
            yera.SetBool("hablando", false);
            yureQuestion.SetActive(true);
            yeraQuestion.SetActive(true);
            yureSprite.SetActive(false);
            yeraSprite.SetActive(false);
            textBox.SetActive(false);
            status = true;
            debesEntrar = false;
            return;

        }
        theText.text = textLines[currentLine];
        if (currentLine.Equals(endLine))
        {
            theText.text = theText.text.Substring(0, 6) + nombre + ", " + theText.text.Substring(6, theText.text.Length - 6);
        }
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

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) currentLine += 1;
    }
}