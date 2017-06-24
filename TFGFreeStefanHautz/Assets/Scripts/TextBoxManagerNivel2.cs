using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public class TextBoxManagerNivel2 : MonoBehaviour {

	public Text theText, theTextWA, score, calculos, text1, text2, text3, text4, text5, text6, text7, text8, solucion;
	public TextAsset textFile;
	public string[] textLines;
	public int currentLine, endLine;
	public Animator yure, yera, kitchen;
	public GameObject scorePanel, objectivePanel, scrollPanel, textBox, textBoxWA, yureQuestion, yeraQuestion, yureSprite, yeraSprite, comprobar, tablaCalculo, candyBagsSprite, star1, star2, star3,
        panelLevel, leaveButt, changeLevelButt, barras;
    public Slider slider1, slider2, slider3, slider4, slider5, slider6, slider7, slider8;
    public AudioSource sound;
    public Button mute;


    private int totalFails, solu = 0;
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
		tablaCalculo.SetActive (status);
		startTime = Time.time;
        candyBagsSprite.SetActive(false);
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
        barras.SetActive(false)
;    }

    public void closeSelector()
    {
        panelLevel.SetActive(false);
        barras.SetActive(true);
    }

    void Update()
	{
		if (debesEntrar == true) {
			textManager ();
		}

		text1.text = slider1.value.ToString();
		text2.text = slider2.value.ToString();
		text3.text = slider3.value.ToString();
		text4.text = slider4.value.ToString ();
		text5.text = slider5.value.ToString();
		text6.text = slider6.value.ToString();
		text7.text = slider7.value.ToString();
		text8.text = slider8.value.ToString();
		solucion.text = "La solución es:\t" + solu + "\tgolosinas/bolsa.";

    }

    public void Quit()
    {
        Application.Quit();
    }

    void OnGUI(){
		tablaCalculo.SetActive(status);
		comprobar.SetActive(status);
		objectivePanel.SetActive(status);
        scrollPanel.SetActive(status);
    }

	public void checkSuccess()
	{
		if (slider1.value.Equals(21) && slider2.value.Equals(42) && slider3.value.Equals(63) && slider4.value.Equals(84) 
			&& slider5.value.Equals(59) && slider6.value.Equals(38) && slider7.value.Equals(17) && slider8.value.Equals(-4) && 
			solu.Equals(3) && !cooldownAnswer)
		{
			status = false;
			scorePanel.SetActive(true);
            leaveButt.SetActive(false);
            changeLevelButt.SetActive(false);
			totalTime = Time.time - startTime;
			score.text= ("¡Has acertado!\n\nTiempo total: " + String.Format("{0:0.00}", totalTime) + "\n\nFallos totales: " + totalFails);
            PlayerPrefs.SetInt("failsLevel2", totalFails);
            PlayerPrefs.SetFloat("timeLevel2", totalTime);
            switch (totalFails)
            {
                case 0:
                    star3.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel2", 3);
                    break;
                case 1:
                    star2.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel2", 2);
                    break;
                case 2:
                    star1.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel2", 1);
                    break;
                default:
                    break;
            }
            candyBagsSprite.SetActive(true);
            yureQuestion.SetActive(false);
            yeraQuestion.SetActive(false);
            yureSprite.SetActive(true);
            yeraSprite.SetActive(true);
        }
		else {
			if (!cooldownAnswer) {
				totalFails++;
				Invoke ("resetCooldown", 5.0f);
				cooldownAnswer = true;
				comprobarButt = comprobar.GetComponent<Button> ();
				comprobarButt.interactable = false;
			}
            if (slider1.value.Equals(21)) text1.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!slider1.value.Equals(21)) text1.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (slider2.value.Equals(42)) text2.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!slider2.value.Equals(42)) text2.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (slider3.value.Equals(63)) text3.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!slider3.value.Equals(63)) text3.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (slider4.value.Equals(84)) text4.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!slider4.value.Equals(84)) text4.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (slider5.value.Equals(59)) text5.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!slider5.value.Equals(59)) text5.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (slider6.value.Equals(38)) text6.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!slider6.value.Equals(38)) text6.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (slider7.value.Equals(17)) text7.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!slider7.value.Equals(17)) text7.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (slider8.value.Equals(-4)) text8.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!slider8.value.Equals(-4)) text8.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
            if (solu.Equals(3)) solucion.color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
            if (!solu.Equals(3)) solucion.color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
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
        if (textLines[currentLine].Substring(0, 4).Equals("Yeyo"))
        {
            textBoxWA.SetActive(true);
            theTextWA.text = textLines[currentLine];
            yera.SetBool("hablando", false);
            yure.SetBool("hablando", false);
            textBox.SetActive(false);
        }
        else
        {
            textBox.SetActive(true);
            textBoxWA.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) currentLine += 1;
    }
}