using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class endScreenManager : MonoBehaviour
{
    public Text scores, starNumber, res1, res2, res3, res4, res5, res6, res7, res8;
    public GameObject panelResults;

    private int totalStars = 0, totalFails = 0;
    private float totalTime = 0f;

    private void Start()
    {

        panelResults.SetActive(false);
        res1.text = "Tiempo Fase 1: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel1")) + "\t\t\t Fallos Fase 1: " + PlayerPrefs.GetInt("failsLevel1");
        res2.text = "Tiempo Fase 2: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel2")) + "\t\t\t Fallos Fase 2: " + PlayerPrefs.GetInt("failsLevel2");
        res3.text = "Tiempo Fase 3: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel3")) + "\t\t\t Fallos Fase 3: " + PlayerPrefs.GetInt("failsLevel3");
        res4.text = "Tiempo Fase 4: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel4")) + "\t\t\t Fallos Fase 4: " + PlayerPrefs.GetInt("failsLevel4");
        res5.text = "Tiempo Fase 5: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel5")) + "\t\t\t Fallos Fase 5: " + PlayerPrefs.GetInt("failsLevel5");
        res6.text = "Tiempo Fase 6: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel6")) + "\t\t\t Fallos Fase 6: " + PlayerPrefs.GetInt("failsLevel6");
        res7.text = "Tiempo Fase 7.1: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel7")) + "\t\t\t Fallos Fase 7: " + PlayerPrefs.GetInt("failsLevel7");
        res8.text = "Tiempo Fase 7.2: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel8")) + "\t\t\t Fallos Fase 8: " + PlayerPrefs.GetInt("failsLevel8");

        totalStars = PlayerPrefs.GetInt("starsLevel1") + PlayerPrefs.GetInt("starsLevel2") + PlayerPrefs.GetInt("starsLevel3") + PlayerPrefs.GetInt("starsLevel4") +
            PlayerPrefs.GetInt("starsLevel5") + PlayerPrefs.GetInt("starsLevel6") + PlayerPrefs.GetInt("starsLevel7") + PlayerPrefs.GetInt("starsLevel8");
        totalTime = PlayerPrefs.GetFloat("timeLevel1") + PlayerPrefs.GetFloat("timeLevel2") + PlayerPrefs.GetFloat("timeLevel3") + PlayerPrefs.GetFloat("timeLevel4") +
            PlayerPrefs.GetFloat("timeLevel5") + PlayerPrefs.GetFloat("timeLevel6") + PlayerPrefs.GetFloat("timeLevel7") + PlayerPrefs.GetFloat("timeLevel8");
        totalFails = PlayerPrefs.GetInt("failsLevel1") + PlayerPrefs.GetInt("failsLevel2") + PlayerPrefs.GetInt("failsLevel3") + PlayerPrefs.GetInt("failsLevel4") +
            PlayerPrefs.GetInt("failsLevel5") + PlayerPrefs.GetInt("failsLevel6") + PlayerPrefs.GetInt("failsLevel7") + PlayerPrefs.GetInt("failsLevel8");
        scores.text = "Tiempo total: " + String.Format("{0:0.00}", totalTime) + "\t Fallos totales: " + totalFails;
        starNumber.text = totalStars.ToString();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void restart() {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("intro");
    }

    public void openResults()
    {
        panelResults.SetActive(true);
    }

    public void closeResults()
    {
        panelResults.SetActive(false);
    }
}
