using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class introScreenManager : MonoBehaviour {

    public Button continueButt, chooseButt;
    public InputField nombre;
    public GameObject panelInfo, panelAuthors, panelAbout, animacion, panelLevel;


    public void Start()
    {
        panelAbout.SetActive(false);
        panelAuthors.SetActive(false);
        panelInfo.SetActive(false);
        panelLevel.SetActive(false);
    }

    public void StartG(string name)
    {
        //Application.LoadLevel(Application.loadedLevel);
        if (nombre.text.Length > 6)
        {
            PlayerPrefs.SetString("playerName", nombre.text);
            nombre.GetComponent<Image>().color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
        }
        else {
            nombre.GetComponent<Image>().color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
        }
        if (PlayerPrefs.HasKey("playerName"))
        {
            SceneManager.LoadScene(name);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ContinueG() {
        SceneManager.LoadScene(PlayerPrefs.GetString("savedLevel"));
    }

    private void Update()
    {
        if (!PlayerPrefs.HasKey("savedLevel"))
        {
            continueButt.interactable = false;
            chooseButt.interactable = false;
        }
        else {
            continueButt.interactable = true;
            chooseButt.interactable = true;
        }

    }
    public void openInfo() {
        panelInfo.SetActive(true);
        animacion.SetActive(false);
    }

    public void closeInfo() {
        panelInfo.SetActive(false);
        animacion.SetActive(true);
    }

    public void openAuthors() {
        panelAuthors.SetActive(true);
        animacion.SetActive(false);
    }

    public void closeAuthors()
    {
        panelAuthors.SetActive(false);
        animacion.SetActive(true);
    }

    public void openAbout() {
        panelAbout.SetActive(true);
        animacion.SetActive(false);
    }

    public void closeAbout()
    {
        panelAbout.SetActive(false);
        animacion.SetActive(true);
    }

    public void openSelector()
    {
        panelLevel.SetActive(true);
        animacion.SetActive(false);
    }

    public void closeSelector()
    {
        panelLevel.SetActive(false);
        animacion.SetActive(true);
    }

    public void loadLevel(string name) {
        SceneManager.LoadScene(name);
    }
}
