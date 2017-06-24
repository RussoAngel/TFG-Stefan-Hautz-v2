using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Log : MonoBehaviour
{

    public Text text;
    public TextAsset textFile;

    // Use this for initialization
    void Start()
    {
        text.text = textFile.text;
    }
}
