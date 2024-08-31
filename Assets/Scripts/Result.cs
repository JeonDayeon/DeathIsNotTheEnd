using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public int result;
    public int chapter;
    public GameObject[] resultBg2;
    public GameObject[] resultBg3;
    public GameObject character;
    public GameObject resultTexts;
    public GameObject[] resultText;

    public string[] cImgPath = new string[10];
    public Sprite[] cImg = new Sprite[8];

    public GameObject ResultCanvas;

    public Button Retry;
    //public Image cimage;

    // Start is called before the first frame update
    void Start()
    {
        Retry.onClick.AddListener(NextChapter);
        result = 0;
        chapter = 0;
        resultBg2 = new GameObject[3];
        resultBg3 = new GameObject[3];

        cImgPath = new string[10];
        cImg = new Sprite[7];
        
        for (int i = 0; i < 3; i++)
        {
            resultBg2[i] = GameObject.Find("resultBg2" + i);
            resultBg3[i] = GameObject.Find("resultBg3" + i);
            resultTexts = GameObject.Find("resultTexts");
        }

        for(int i = 0; i < 7; i++)
        {
            cImgPath[i] = "Assets/Character/c" + i + ".png";
            cImg[i] = AssetDatabase.LoadAssetAtPath<Sprite>(cImgPath[i]);
        }

        character = GameObject.Find("character");

        ResultCanvas = GameObject.Find("ResultCanvas");

        ResultCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void resultUICharacter(int chapter, int result)
    {
        if(chapter == 0)
        {

            if(result == 0) character.GetComponent<Image>().sprite = cImg[0];
            if (result == 1) character.GetComponent<Image>().sprite = cImg[1];
            if (result == 2) {
                character.GetComponent<Image>().sprite = cImg[6];
            }
        }

        if (chapter == 1)
        {
            if (result == 0) character.GetComponent<Image>().sprite = cImg[5];
            if (result == 1) character.GetComponent<Image>().sprite = cImg[4];
            if (result == 2) character.GetComponent<Image>().sprite = cImg[3];
        }

        if (chapter == 2)
        {
            if (result == 0) character.GetComponent<Image>().sprite = cImg[6];
            if (result == 1) character.GetComponent<Image>().sprite = cImg[2];
            if (result == 2){
                //character.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                character.GetComponent<Image>().sprite = cImg[6];
            }
        }

    }

    public void resultUI(int chapter, int result, List<string> InteractResultAll)
    {
        ResultCanvas.SetActive(true);
        resultText = new GameObject[InteractResultAll.Count];

        for (int i = 0; i < InteractResultAll.Count; i++)
        {
            resultText[i] = resultTexts.transform.GetChild(i).gameObject;
            resultText[i].GetComponent<TextMeshProUGUI>().text = InteractResultAll[i];
        }
        
        if (chapter == 0)
        {
            if (result == 0)
            {
                resultBg2[0].SetActive(true);
                resultBg2[1].SetActive(false);
                resultBg2[2].SetActive(false);

                resultBg3[0].SetActive(false);
                resultBg3[1].SetActive(false);
                resultBg3[2].SetActive(true);
            }
            if (result == 1)
            {
                resultBg2[0].SetActive(true);
                resultBg2[1].SetActive(false);
                resultBg2[2].SetActive(false);

                resultBg3[0].SetActive(false);
                resultBg3[1].SetActive(true);
                resultBg3[2].SetActive(false);
            }
                
            
            if (result == 2)
            {
                resultBg2[0].SetActive(false);
                resultBg2[1].SetActive(true);
                resultBg2[2].SetActive(true);

                resultBg3[0].SetActive(false);
                resultBg3[1].SetActive(false);
                resultBg3[2].SetActive(false);
            }

        }
        if (chapter == 1)
        {
            resultBg2[0].SetActive(true);
            resultBg2[1].SetActive(false);
            resultBg2[2].SetActive(false);

            if(result == 0)
            {
                resultBg3[0].SetActive(true);
                resultBg3[1].SetActive(false);
                resultBg3[2].SetActive(false);
            }
            if(result == 1)
            {
                resultBg3[0].SetActive(false);
                resultBg3[1].SetActive(true);
                resultBg3[2].SetActive(false);
            }
            if(result == 2)
            {
                resultBg3[0].SetActive(false);
                resultBg3[1].SetActive(false);
                resultBg3[2].SetActive(true);
            }

        }

        if (chapter == 2)
        {
            resultBg2[0].SetActive(true);
            resultBg2[1].SetActive(false);
            resultBg2[2].SetActive(false);

            if (result == 0)
            {
                resultBg3[0].SetActive(true);
                resultBg3[1].SetActive(false);
                resultBg3[2].SetActive(false);
            }
            if (result == 1)
            {
                resultBg3[0].SetActive(false);
                resultBg3[1].SetActive(true);
                resultBg3[2].SetActive(false);
            }
            if (result == 2)
            {
                resultBg3[0].SetActive(false);
                resultBg3[1].SetActive(false);
                resultBg3[2].SetActive(false);
            }
        }
        resultUICharacter(chapter, result);
    }

    public void NextChapter()
    {
        SceneManager.LoadScene(0);
    }
}
