using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectInteractBtn : MonoBehaviour
{
    protected bool isResult;
    protected string Chat;
    protected string Item;
    protected string Result;
    protected InteractResult.ResultType Type;

    private GameManager gameManager;

    Button btn;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectInteract);
    }
    public void SelectInteract()
    {
        Debug.Log("AddListen");
        if(isResult)
        {
            gameManager.InteractionResultAll.Add(Result);
        }

        switch(Type)
        {
            case InteractResult.ResultType.None:
                gameManager.ResultInteractBox();
                break;

            case InteractResult.ResultType.EquipInHand:
                if (gameManager.UseObj.Count < 2)
                    gameManager.UseObj.Add(Item);
                else
                    Debug.Log("양손 가득 들고 있습니다.");
                break;
        }
        gameManager.ResultInteractBox();
    }

    public void SetInteractResult(bool _isResult,string _Chat,string _Item,string _Result, InteractResult.ResultType _Type)
    {
        isResult = _isResult;
        Chat = _Chat;
        Item = _Item;
        Result = _Result;
        Type = _Type;
    }                  
}
