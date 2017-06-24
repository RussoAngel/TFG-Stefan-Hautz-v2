using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public class TextBoxManagerNivel1 : MonoBehaviour {

    public Text theText, score, calculos;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine, endLine;
    public Animator yure, yera, kitchen;
    public GameObject scorePanel, objectivePanel, scrollPanel, comprobar, tablaCalculo, yureSprite, yeraSprite, yureQuestion, yeraQuestion, candyBagsSprite, textBox, star1, star2, star3, panelLevel,
        leaveButt, changeLevelButt;
    public AudioSource sound;
    public Button mute;

    private int totalFails, solu1 = 0, solu2 = 0;
    private float totalTime, startTime;
	private bool status = false, debesEntrar = true, cooldownAnswer = false;
	private Button comprobarButt;
    private string nombre;


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

	void resetCooldown(){
		cooldownAnswer = false;
		comprobarButt.interactable = true;
	}

	public void increaseSolu1(){
        if (solu1 < 99) solu1++;
	}

	public void increaseSolu2(){
        if (solu2 < 99) solu2++;
	}

	public void decreaseSolu1(){
        if (solu1 > 0) solu1--;
	}

	public void decreaseSolu2(){
        if (solu2 > 0) solu2--;
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
        //eggsText.text = eggs.value.ToString("0.00");
		if (debesEntrar == true) {
			textManager ();
		}
        
		calculos.text = "Nº de golosinas\t\t\t\t\t80\t\t\t80\t\t\t80\nNº de bolsas\t\t\t\t\t\t10\t\t\t20\t\t\t40\nNº de golosinas/bolsa\t\t\t8\t\t\t"+solu1+"\t\t\t"+solu2;

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
		if (solu1.Equals(4) && solu2.Equals(2) && !cooldownAnswer)
        {
			status = false;
            scorePanel.SetActive(true);
            leaveButt.SetActive(false);
            changeLevelButt.SetActive(false);
            totalTime = Time.time - startTime;
            score.text= ("¡Has acertado!\n\nTiempo total: " + String.Format("{0:0.00}", totalTime) + "\n\nFallos totales: " + totalFails);
            PlayerPrefs.SetInt("failsLevel1", totalFails);
            PlayerPrefs.SetFloat("timeLevel1", totalTime);
            switch (totalFails)
            {
                case 0:
                    star3.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel1", 3);
                    break;
                case 1:
                    star2.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel1", 2);
                    break;
                case 2:
                    star1.SetActive(true);
                    PlayerPrefs.SetInt("starsLevel1", 1);
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
