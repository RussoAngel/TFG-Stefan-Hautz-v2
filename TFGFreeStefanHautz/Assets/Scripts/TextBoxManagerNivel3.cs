using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public class TextBoxManagerNivel3 : MonoBehaviour {

	public Text theText, theTextWA, theTextWAYure, solucion, score;
	public TextAsset textFile;
	public string[] textLines;
	public int currentLine, endLine;
	public Animator yure, yera;
	public GameObject scorePanel, objectivePanel, comproPanel, scrollPanel, comprobar, tablaDrag, cas1, cas2, cas3, cas4, cas5, cas6, 
        cas7, cas8, cas9, cas10, cas11, cas12, cas13, panelRespuestas1, panelRespuestas2, yureQuestion, yeraQuestion, yureSprite, yeraSprite, 
        textBox, textBoxWA, textBoxWAYure, star1, star2, star3, panelLevel, leaveButt, changeLevelButt;
    public AudioSource sound;
    public Button mute;

    private int totalFails, solu = 0;
	private float totalTime, startTime;
    private bool status = false, debesEntrar = true, cooldownAnswer = false, valid1 = false, valid2 = false, segundaFase = false;
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
		tablaDrag.SetActive (status);
        comproPanel.SetActive(false);
		startTime = Time.time;
        yureQuestion.SetActive(false);
        yeraQuestion.SetActive(false);
        PlayerPrefs.SetString("savedLevel", SceneManager.GetActiveScene().name);
        nombre = PlayerPrefs.GetString("playerName").Split(' ').First();
    }
	public void increaseSolu(){
        if (solu < 99) solu++;
	}

	public void decreaseSolu(){
        if (solu > 0) solu--;
	}

	void resetCooldown(){
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
		if (debesEntrar == true) {
			textManager ();
		}
			
		solucion.text = "La solución es:\t" + solu;
        if (!cas1.transform.childCount.Equals(0) && !cas2.transform.childCount.Equals(0) && !cas3.transform.childCount.Equals(0) &&
            !cas4.transform.childCount.Equals(0) && !cas5.transform.childCount.Equals(0) && !cas6.transform.childCount.Equals(0))
        {
            contenidoCas1 = cas1.transform.GetChild(0).name + cas2.transform.GetChild(0).name + cas3.transform.GetChild(0).name +
                cas4.transform.GetChild(0).name + cas5.transform.GetChild(0).name + cas6.transform.GetChild(0).name;
        }

        if (contenidoCas1.Equals("80=21X+17") || contenidoCas1.Equals("80=17+21X") || contenidoCas1.Equals("21X+17=80") ||
            contenidoCas1.Equals("17+21X=80"))
        {
            valid1 = true;
        }
        else {
            valid1 = false;
        }

        if (!cas7.transform.childCount.Equals(0) && !cas8.transform.childCount.Equals(0) && !cas9.transform.childCount.Equals(0) &&
            !cas10.transform.childCount.Equals(0) && !cas11.transform.childCount.Equals(0) && !cas12.transform.childCount.Equals(0) && 
            !cas13.transform.childCount.Equals(0)
            )
        {
            contenidoCas2 = cas7.transform.GetChild(0).name + cas8.transform.GetChild(0).name + cas9.transform.GetChild(0).name +
                cas10.transform.GetChild(0).name + cas11.transform.GetChild(0).name + cas12.transform.GetChild(0).name + cas13.transform.GetChild(0).name;
        }

        if (contenidoCas2.Equals("80=21x3+17") || contenidoCas2.Equals("80=17+21x3") || contenidoCas2.Equals("21x3+17=80") ||
            contenidoCas2.Equals("17+21x3=80"))
        {
            valid2 = true;
        }
        else
        {
            valid2 = false;
        }

    }

    public void Quit()
    {
        Application.Quit();
    }

    void OnGUI(){
		tablaDrag.SetActive(status);
		comprobar.SetActive(status);
		objectivePanel.SetActive(status);
        scrollPanel.SetActive(status);
    }

	public void checkSuccess()
	{
        if (valid2 && !cooldownAnswer)
        {
            status = false;
            comproPanel.SetActive(false);
            scorePanel.SetActive(true);
            leaveButt.SetActive(false);
            changeLevelButt.SetActive(false);
            totalTime = Time.time - startTime;
            score.text = ("¡Has acertado!\n\nTiempo total: " + String.Format("{0:0.00}", totalTime) + "\n\nFallos totales: " + totalFails);
            PlayerPrefs.SetInt("failsLevel3", totalFails);
            PlayerPrefs.SetFloat("timeLevel3", totalTime);
            switch (totalFails)
            {
                case 0:
                    star3.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel3", 3);
                    break;
                case 1:
                    star2.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel3", 2);
                    break;
                case 2:
                    star1.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel3", 1);
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
            if (segundaFase && !cooldownAnswer)
            {
                totalFails++;
                Invoke("resetCooldown", 5.0f);
                cooldownAnswer = true;
                comprobarButt = comprobar.GetComponent<Button>();
                comprobarButt.interactable = false;
            }
            if (!valid2 && segundaFase) panelRespuestas2.GetComponent<Image>().color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
        }

        if (!segundaFase && valid1 && solu.Equals(3) && !cooldownAnswer)
        {
            comproPanel.SetActive(true);
            segundaFase = true;
        }
        else
        {
            if (!segundaFase && !cooldownAnswer)
            {
                totalFails++;
                Invoke("resetCooldown", 5.0f);
                cooldownAnswer = true;
                comprobarButt = comprobar.GetComponent<Button>();
                comprobarButt.interactable = false;
            }
            if (!valid1) panelRespuestas1.GetComponent<Image>().color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (valid1) panelRespuestas1.GetComponent<Image>().color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
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