using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public class TextBoxManagerNivel4 : MonoBehaviour
{
    public Text theText, theTextWA, theTextWAYure, text1, text2, text3, text4, text5, text6, text7, bolsas, solucion, formula, score;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine, endLine;
    public Animator yure, yera;
    public GameObject scorePanel, objectivePanel, scrollPanel, comprobar, tablaCalculo, yureQuestion, yeraQuestion, yureSprite, yeraSprite, textBox, textBoxWA, textBoxWAYure,
        star1, star2, star3, panelLevel, leaveButt, changeLevelButt;
    public Slider slider1, slider2, slider3, slider4, slider5, slider6, slider7;
    public Button afirm1, afirm2, afirm3, afirm4, afirm5, afirm6;
    public AudioSource sound;
    public Button mute;

    private int totalFails, solu1 = 0, solu2 = 0;
    private float totalTime, startTime;
    private bool status = false, debesEntrar = true, cooldownAnswer = false;
    private Button comprobarButt;
    private string nombre;

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
        tablaCalculo.SetActive(status);
        startTime = Time.time;
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

    public void increaseBolsas()
    {
        if (solu2 < 99) solu2++;
    }

    public void decreaseBolsas()
    {
        if (solu2 > 0) solu2--;
    }

    public void triggerAfirm1() {
        if (afirm1.GetComponentInChildren<Text>().text.Equals("Si"))
        {
            afirm1.GetComponentInChildren<Text>().text = "No";
            afirm1.GetComponent<Image>().color = new Color32(0xFF, 0x7D, 0x00, 0xFF);
            
        }
        else {
            afirm1.GetComponentInChildren<Text>().text = "Si";
            afirm1.GetComponent<Image>().color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
        }

    }
    public void triggerAfirm2() {
        if (afirm2.GetComponentInChildren<Text>().text.Equals("Si"))
        {
            afirm2.GetComponentInChildren<Text>().text = "No";
            afirm2.GetComponent<Image>().color = new Color32(0xFF, 0x7D, 0x00, 0xFF);
            
        }
        else {
            afirm2.GetComponentInChildren<Text>().text = "Si";
            afirm2.GetComponent<Image>().color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
        }

    }
    public void triggerAfirm3() {
        if (afirm3.GetComponentInChildren<Text>().text.Equals("Si"))
        {
            afirm3.GetComponentInChildren<Text>().text = "No";
            afirm3.GetComponent<Image>().color = new Color32(0xFF, 0x7D, 0x00, 0xFF);
            
        }
        else {
            afirm3.GetComponentInChildren<Text>().text = "Si";
            afirm3.GetComponent<Image>().color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
        }

    }
    public void triggerAfirm4() {
        if (afirm4.GetComponentInChildren<Text>().text.Equals("Si"))
        {
            afirm4.GetComponentInChildren<Text>().text = "No";
            afirm4.GetComponent<Image>().color = new Color32(0xFF, 0x7D, 0x00, 0xFF);
            
        }
        else {
            afirm4.GetComponentInChildren<Text>().text = "Si";
            afirm4.GetComponent<Image>().color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
        }

    }
    public void triggerAfirm5() {
        if (afirm5.GetComponentInChildren<Text>().text.Equals("Si"))
        {
            afirm5.GetComponentInChildren<Text>().text = "No";
            afirm5.GetComponent<Image>().color = new Color32(0xFF, 0x7D, 0x00, 0xFF);
            
        }
        else {
            afirm5.GetComponentInChildren<Text>().text = "Si";
            afirm5.GetComponent<Image>().color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
        }

    }
    public void triggerAfirm6() {
        if (afirm6.GetComponentInChildren<Text>().text.Equals("Si"))
        {
            afirm6.GetComponentInChildren<Text>().text = "No";
            afirm6.GetComponent<Image>().color = new Color32(0xFF, 0x7D, 0x00, 0xFF);
            
        }
        else {
            afirm6.GetComponentInChildren<Text>().text = "Si";
            afirm6.GetComponent<Image>().color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
        }

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

        text1.text = slider1.value.ToString();
        text2.text = slider2.value.ToString();
        text3.text = slider3.value.ToString();
        text4.text = slider4.value.ToString();
        text5.text = slider5.value.ToString();
        text6.text = slider6.value.ToString();
        text7.text = slider7.value.ToString();
        solucion.text = "La solución es: " + solu1 + "\t\tbolsas.";
        bolsas.text = solu2.ToString();
        formula.text = "6 · " + solu2 + " + 8 =";

    }

    public void Quit()
    {
        Application.Quit();
    }

    void OnGUI()
    {
        tablaCalculo.SetActive(status);
        comprobar.SetActive(status);
        objectivePanel.SetActive(status);
        scrollPanel.SetActive(status);
    }

    public void checkSuccess()
    {
        if (slider1.value.Equals(14) && slider2.value.Equals(20) && slider3.value.Equals(26) && slider4.value.Equals(50)
            && slider5.value.Equals(68) && slider6.value.Equals(98) && slider7.value.Equals(80)
            && solu1.Equals(12) && solu2.Equals(12) && afirm1.GetComponentInChildren<Text>().text.Equals("No")
            && afirm2.GetComponentInChildren<Text>().text.Equals("No") && afirm3.GetComponentInChildren<Text>().text.Equals("No") 
            && afirm4.GetComponentInChildren<Text>().text.Equals("No") && afirm5.GetComponentInChildren<Text>().text.Equals("No") 
            && afirm6.GetComponentInChildren<Text>().text.Equals("No") && !cooldownAnswer)
        {
            status = false;
            scorePanel.SetActive(true);
            changeLevelButt.SetActive(false);
            leaveButt.SetActive(false);
            totalTime = Time.time - startTime;
            score.text = ("¡Has acertado!\n\nTiempo total: " + String.Format("{0:0.00}", totalTime) + "\n\nFallos totales: " + totalFails);
            PlayerPrefs.SetInt("failsLevel4", totalFails);
            PlayerPrefs.SetFloat("timeLevel4", totalTime);
            switch (totalFails)
            {
                case 0:
                    star3.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel4", 3);
                    break;
                case 1:
                    star2.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel4", 2);
                    break;
                case 2:
                    star1.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel4", 1);
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
            if (slider1.value.Equals(14)) text1.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!slider1.value.Equals(14)) text1.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (slider2.value.Equals(20)) text2.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!slider2.value.Equals(20)) text2.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (slider3.value.Equals(26)) text3.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!slider3.value.Equals(26)) text3.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (slider4.value.Equals(50)) text4.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!slider4.value.Equals(50)) text4.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (slider5.value.Equals(68)) text5.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!slider5.value.Equals(68)) text5.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (slider6.value.Equals(98)) text6.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!slider6.value.Equals(98)) text6.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (slider7.value.Equals(80)) text7.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!slider7.value.Equals(80)) text7.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);

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


        if (textLines[currentLine].Substring(0, 6).Equals("WAYure"))
        {
            textBoxWAYure.SetActive(true);
            textBoxWA.SetActive(false);
            textBox.SetActive(false);
            yera.SetBool("hablando", false);
            yure.SetBool("hablando", true);
            theTextWAYure.text = textLines[currentLine];
            theTextWAYure.text = theTextWAYure.text.Substring(2, theTextWAYure.text.Length - 2);
        }
        else
        {

            if (textLines[currentLine].Substring(0, 4).Equals("Yeyo"))
            {
                textBoxWA.SetActive(true);
                theTextWA.text = textLines[currentLine];
                yera.SetBool("hablando", false);
                yure.SetBool("hablando", false);
                textBox.SetActive(false);
                textBoxWAYure.SetActive(false);
            }
            else
            {
                textBox.SetActive(true);
                textBoxWA.SetActive(false);
                textBoxWAYure.SetActive(false);
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
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) currentLine += 1;
    }
}