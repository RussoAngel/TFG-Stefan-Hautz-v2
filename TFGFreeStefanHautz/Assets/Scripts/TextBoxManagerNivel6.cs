using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public class TextBoxManagerNivel6 : MonoBehaviour
{

    public Text theText, score, lin1, lin2, lin3, lin4, solucion1, solucion2;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine, endLine;
    public Animator yure, yera, kitchen;
    public GameObject scorePanel, textBox, objectivePanel, scrollPanel, comprobar, tablaDrag, cas1, cas2, cas3, 
        cas4, cas5, cas6, yureQuestion, yeraQuestion, yureSprite, yeraSprite, panelRespuesta1, panelRespuesta2, star1, star2, star3, panelLevel, leaveButt, changeLevelButt;
    public AudioSource sound;
    public Button mute;

    private int totalFails, soluTeo1 = -1, soluTeo2 = -1, soluTeo3 = -1, soluTeo4 = -1, solu1 = 0, solu2 = 0; //Poner a -1
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
        yureQuestion.SetActive(false);
        yeraQuestion.SetActive(false);
        PlayerPrefs.SetString("savedLevel", SceneManager.GetActiveScene().name);
        lin1.text = "_______";
        lin2.text = "_______";
        lin3.text = "_______";
        lin4.text = "_______";
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

    public void increaseSoluteo1()
    {
        if(soluTeo1 < 3) soluTeo1++;
    }

    public void decreaseSoluTeo1()
    {
        if (soluTeo1 > 0) soluTeo1--;
    }

    public void increaseSoluteo2()
    {
        if(soluTeo2 < 3) soluTeo2++;
    }

    public void decreaseSoluTeo2()
    {
        if (soluTeo2 > 0) soluTeo2--;
    }

    public void increaseSoluteo3()
    {
        if(soluTeo3 < 3) soluTeo3++;
    }

    public void decreaseSoluTeo3()
    {
        if (soluTeo3 > 0) soluTeo3--;
    }

    public void increaseSoluteo4()
    {
        if(soluTeo4 < 3) soluTeo4++;
    }

    public void decreaseSoluTeo4()
    {
        if (soluTeo4 > 0) soluTeo4--;
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
        switch (soluTeo1)
        {
            case 0:
                lin1.text = "sumando";
                break;    
            case 1:
                lin1.text = "restando";
                break;
            case 2:
                lin1.text = "multiplicando";
                break;
            case 3:
                lin1.text = "dividiendo";
                break;
        }

        switch (soluTeo2)
        {
            case 0:
                lin2.text = "sumas";
                break;    
            case 1:
                lin2.text = "restas";
                break;
            case 2:
                lin2.text = "multiplicas";
                break;
            case 3:
                lin2.text = "divides";
                break;
        }

        switch (soluTeo3)
        {
            case 0:
                lin3.text = "sumando";
                break;    
            case 1:
                lin3.text = "restando";
                break;
            case 2:
                lin3.text = "multiplicando";
                break;
            case 3:
                lin3.text = "dividiendo";
                break;
        }

        switch (soluTeo4)
        {
            case 0:
                lin4.text = "suma";
                break;    
            case 1:
                lin4.text = "resta";
                break;
            case 2:
                lin4.text = "multiplica";
                break;
            case 3:
                lin4.text = "divide";
                break;
        }

        if (debesEntrar == true)
        {
            textManager();
        }

        if (!cas1.transform.childCount.Equals(0) && !cas2.transform.childCount.Equals(0) && !cas3.transform.childCount.Equals(0))
        {
            contenidoCas1 = cas1.transform.GetChild(0).name + cas2.transform.GetChild(0).name + cas3.transform.GetChild(0).name;
        }

        if (!cas4.transform.childCount.Equals(0) && !cas5.transform.childCount.Equals(0) && !cas6.transform.childCount.Equals(0))
        {
            contenidoCas2 = cas4.transform.GetChild(0).name + cas5.transform.GetChild(0).name + cas6.transform.GetChild(0).name;
        }

        if (contenidoCas1.Equals("50-20"))
        {
            valid1 = true;
        }
        else
        {
            valid1 = false;
        }

        if (contenidoCas2.Equals("30/2"))
        {
            valid2 = true;
        }
        else
        {
            valid2 = false;
        }

        solucion1.text = solu1.ToString();
        solucion2.text = solu2.ToString();

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
        if (valid1 && valid2 && soluTeo1.Equals(1) && soluTeo2.Equals(1) && soluTeo3.Equals(3) && soluTeo4.Equals(3) &&
            solu1.Equals(30) && solu2.Equals(15) && !cooldownAnswer)
        {
            status = false;
            scorePanel.SetActive(true);
            changeLevelButt.SetActive(false);
            leaveButt.SetActive(false);
            totalTime = Time.time - startTime;
            score.text = ("¡Has acertado!\n\nTiempo total: " + String.Format("{0:0.00}", totalTime) + "\n\nFallos totales: " + totalFails);
            PlayerPrefs.SetInt("failsLevel6", totalFails);
            PlayerPrefs.SetFloat("timeLevel6", totalTime);
            switch (totalFails)
            {
                case 0:
                    star3.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel6", 3);
                    break;
                case 1:
                    star2.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel6", 2);
                    break;
                case 2:
                    star1.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel6", 1);
                    break;
                default:
                    break;
            }
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
            if (solu1.Equals(30)) solucion1.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!solu1.Equals(30)) solucion1.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (solu2.Equals(15)) solucion2.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!solu2.Equals(15)) solucion2.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
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