using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public class TextBoxManagerNivel8 : MonoBehaviour
{

    public Text theText, score, lin1, lin2;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine, endLine;
    public Animator yure, yera;
    public GameObject scorePanel, textBox, objectivePanel, scrollPanel, comprobar, tablaDrag, cas1, cas2, cas3, 
        cas4, cas5, cas6, cas7, cas8, cas9, cas10, cas11, cas12, cas13, cas14, cas15, cas16, cas17, colaSprite, colaSprite2,
        yureQuestion, yeraQuestion, yureSprite, yeraSprite, panelRespuesta1, panelRespuesta2, panelRespuesta3, star1, star2, star3, panelLevel, leaveButt, changeLevelButt;
    public AudioSource sound;
    public Button mute;

    private int totalFails, solu1 = 0, solu2 = 0;
    private float totalTime, startTime;
    private bool status = false, debesEntrar = true, cooldownAnswer = false, valid1 = false, valid2 = false, valid3 = false;
    private Button comprobarButt;
    private String contenidoCas1 = "", contenidoCas2 = "", contenidoCas3 = "", nombre;

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
        colaSprite.SetActive(false);
        colaSprite2.SetActive(false);
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

        if (!cas1.transform.childCount.Equals(0) && !cas2.transform.childCount.Equals(0) && !cas3.transform.childCount.Equals(0) && !cas4.transform.childCount.Equals(0))
        {
            contenidoCas1 = cas1.transform.GetChild(0).name + cas2.transform.GetChild(0).name + cas3.transform.GetChild(0).name + cas4.transform.GetChild(0).name;
        }

        if (!cas5.transform.childCount.Equals(0) && !cas6.transform.childCount.Equals(0) && !cas7.transform.childCount.Equals(0) && !cas8.transform.childCount.Equals(0))
        {
            contenidoCas2 = cas5.transform.GetChild(0).name + cas6.transform.GetChild(0).name + cas7.transform.GetChild(0).name + cas8.transform.GetChild(0).name;
        }

        if (!cas9.transform.childCount.Equals(0) && !cas10.transform.childCount.Equals(0) && !cas11.transform.childCount.Equals(0) &&
            !cas12.transform.childCount.Equals(0) && !cas13.transform.childCount.Equals(0) && !cas14.transform.childCount.Equals(0) &&
            !cas15.transform.childCount.Equals(0) && !cas16.transform.childCount.Equals(0) && !cas17.transform.childCount.Equals(0))
        {
            contenidoCas3 = cas9.transform.GetChild(0).name + cas10.transform.GetChild(0).name + cas11.transform.GetChild(0).name +
                cas12.transform.GetChild(0).name + cas13.transform.GetChild(0).name + cas14.transform.GetChild(0).name +
                cas15.transform.GetChild(0).name + cas16.transform.GetChild(0).name + cas17.transform.GetChild(0).name;
        }

        if (contenidoCas1.Equals("8X+4") || contenidoCas1.Equals("4+8X"))
        {
            valid1 = true;
        }
        else
        {
            valid1 = false;
        }

        if (contenidoCas2.Equals("12X-4"))
        {
            valid2 = true;
        }
        else
        {
            valid2 = false;
        }
        if (contenidoCas3.Equals("12X-4=8X+4") || contenidoCas3.Equals("12X-4=4+8X") || contenidoCas3.Equals("8X+4=12X-4") ||
            contenidoCas3.Equals("4+8X=12X-4")) //contenidoCas3.Equals("12X-8X=4+4")¿?
        {
            valid3 = true;
        }
        else
        {
            valid3 = false;
        }

        lin1.text = "Precio de cada refresco: " + solu1 + "€";
        lin2.text = "Dinero disponible: "+ solu2 + "€";

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
        if (valid1 && valid2 && valid3 && solu1.Equals(2) && solu2.Equals(20) && !cooldownAnswer)
        {
            status = false;
            scorePanel.SetActive(true);
            leaveButt.SetActive(false);
            changeLevelButt.SetActive(false);
            totalTime = Time.time - startTime;
            score.text = ("¡Has acertado!\n\nTiempo total: " + String.Format("{0:0.00}", totalTime) + "\n\nFallos totales: " + totalFails);
            PlayerPrefs.SetInt("failsLevel8", totalFails);
            PlayerPrefs.SetFloat("timeLevel8", totalTime);
            switch (totalFails)
            {
                case 0:
                    star3.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel8", 3);
                    break;
                case 1:
                    star2.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel8", 2);
                    break;
                case 2:
                    star1.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel8", 1);
                    break;
                default:
                    break;
            }
            colaSprite.SetActive(true);
            colaSprite2.SetActive(true);
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
            if (!valid3) panelRespuesta3.GetComponent<Image>().color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (valid3) panelRespuesta3.GetComponent<Image>().color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (solu1.Equals(2)) lin1.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!solu1.Equals(2)) lin1.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (solu2.Equals(20)) lin2.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!solu2.Equals(20)) lin2.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
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