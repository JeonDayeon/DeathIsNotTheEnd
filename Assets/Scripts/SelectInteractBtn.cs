using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectInteractBtn : MonoBehaviour
{
    public bool isResult;
    public string Chat;
    public string Item;
    public string Result;

    public InteractResult.ResultType Type;

    public GameObject character;
    public Sprite[] cImg = new Sprite[8];

    private GameManager gameManager;

    Button btn;

    public bool isEnding;
    public int EndingNumber;

    private Result resultStageEnding;

    public TextMeshProUGUI CharRole;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectInteract);

        resultStageEnding = FindObjectOfType<Result>();
    }
    public void SelectInteract()
    {
        Debug.Log("AddListen");
        if(isResult)
        {
            if (isEnding)
                gameManager.InteractionResultAll.Insert(0, Result);
            else
                gameManager.InteractionResultAll.Add(Result);
        }

        switch(Type)
        {
            case InteractResult.ResultType.None:
                break;

            case InteractResult.ResultType.EquipInHand:
                if (gameManager.UseObj.Count < 2)
                    gameManager.UseObj.Add(Item);
                else
                    Debug.Log("양손 가득 들고 있습니다.");
                break;
        }
        gameManager.ResultInteractBox(isEnding);

        if(isEnding)
        {
            int chapter = gameManager.Chapter;
            int result_ = EndingNumber;
            if (chapter == 0)
            {

                if (result_ == 0)
                { 
                    character.GetComponent<Image>().sprite = cImg[0];
                    CharRole.text = new string ("나는 범죄자다.");
                }
                if (result_ == 1)
                {
                    character.GetComponent<Image>().sprite = cImg[1];
                    CharRole.text = new string ("나는 경찰이다.");
                }
                if (result_ == 2)
                {
                    character.GetComponent<Image>().sprite = cImg[4];
                    CharRole.text = new string("나는 시민 영웅이다.");
                }
            }

            if (chapter == 1)
            {
                if (result_ == 0) character.GetComponent<Image>().sprite = cImg[5];
                if (result_ == 1) character.GetComponent<Image>().sprite = cImg[4];
                if (result_ == 2) character.GetComponent<Image>().sprite = cImg[3];
            }

            if (chapter == 2)
            {
                if (result_ == 0) character.GetComponent<Image>().sprite = cImg[6];
                if (result_ == 1) character.GetComponent<Image>().sprite = cImg[2];
                if (result_ == 2)
                {

                    character.GetComponent<Image>().sprite = cImg[6];
                }
            }


            Invoke("MoveResult", 5f);
        }
    }

    public void SetInteractResult(bool _isResult,string _Chat,string _Item,string _Result, InteractResult.ResultType _Type)
    {
        isResult = _isResult;
        Chat = _Chat;
        Item = _Item;
        Result = _Result;
        Type = _Type;
    } 
    
    public void MoveResult()
    {
        resultStageEnding.resultUI(gameManager.Chapter, EndingNumber, gameManager.InteractionResultAll);
    }
}
