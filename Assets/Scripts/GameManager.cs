using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int Chapter = 0;
    public GameObject InteractionBox;
    public TextMeshProUGUI InteractionObjTmp;
    public TextMeshProUGUI InteractionAll;
    public GameObject DirObjectBtns;
    public GameObject DirObjBtnsBG;

    public List<string> UseObj = new List<string>(2);
    public List<string> InteractionResultAll = new List<string>(1);

    // Start is called before the first frame update
    void Start()
    {
        InteractionBox = GameObject.Find("InteractionBox").gameObject;
        InteractionObjTmp = InteractionBox.transform.Find("ObjText").GetComponent<TextMeshProUGUI>();
        DirObjectBtns = InteractionBox.transform.Find("InteractionBtns").gameObject;
        InteractionAll = InteractionBox.transform.Find("InteractAll").GetComponent<TextMeshProUGUI>();
        DirObjBtnsBG = GameObject.Find("InteractionBtnsNull").gameObject;
        DirObjBtnsBG.SetActive(false);
        Debug.Log(InteractionBox.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InteractionAll.gameObject.SetActive(false);
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));
            RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero, 0f);

            if (hit.collider != null)
            {
                GameObject clicks = hit.transform.gameObject;
                Debug.Log(clicks.name);
                InteractDirObject InteractObj = clicks.GetComponent<InteractDirObject>();
                if (InteractObj != null)
                {
                    for (int i = 0; i < DirObjectBtns.transform.childCount; i++)
                    {
                        Button DirObjectBtn = DirObjectBtns.transform.GetChild(i).GetComponent<Button>();
                        DirObjectBtn.gameObject.SetActive(false);
                        Button DirObjectBtnBG = DirObjBtnsBG.transform.GetChild(i).GetComponent<Button>();
                        DirObjectBtnBG.gameObject.SetActive(false);
                    }
                    InteractionAll.gameObject.SetActive(false);
                    SetInteractBox(InteractObj);
                }
            }
        }
    }

    public void AddUseObj(string NewObj)
    {
        if(!UseObj.Contains(NewObj))
            UseObj.Add(NewObj);
    }

    public void ResultInteractBox(bool isEnding)
    {
        InteractionObjTmp.text = "다음 상황에서 나는 어떻게 행동할까?";
        for (int i = 0; i < DirObjectBtns.transform.childCount; i++)
        {
            Button DirObjectBtn = DirObjectBtns.transform.GetChild(i).GetComponent<Button>();
            DirObjectBtn.gameObject.SetActive(false);
            Button DirObjectBtnBG = DirObjBtnsBG.transform.GetChild(i).GetComponent<Button>();
            DirObjectBtnBG.gameObject.SetActive(false);
        }

        
        InteractionAll.gameObject.SetActive(true);
        if (isEnding || InteractionResultAll.Count <= 0)
            InteractionAll.text = InteractionResultAll[0];
        else
        {
            InteractionAll.text = InteractionResultAll[InteractionResultAll.Count - 1];
        }
    }
    public void SetInteractBox(InteractDirObject InteractObj)
    {
        DirObjBtnsBG.SetActive(true);

        InteractionObjTmp.text = InteractObj.ObjText;

        if(InteractObj.InteractOptions != null)
        {
            for(int i = 0; i < InteractObj.InteractOptions.Count; i++)
            {
                Button DirObjectBtn;
                if (InteractObj.InteractOptions.Count > 0)
                {
                    DirObjBtnsBG.transform.GetChild(i).gameObject.SetActive(true);
                    DirObjectBtn = DirObjectBtns.transform.GetChild(i).GetComponent<Button>();
                    int HaveItemNum = 0;

                    if (InteractObj.InteractOptions[i].Conditions.Length > 0)
                    {
                        for (int Nnum = 0; Nnum < InteractObj.InteractOptions[i].Conditions.Length; Nnum++)
                        {
                            if (UseObj.Contains(InteractObj.InteractOptions[i].Conditions[Nnum]))
                            {
                                HaveItemNum++;
                            }
                        }
                        if (InteractObj.InteractOptions[i].Conditions.Length == HaveItemNum)
                        {
                            DirObjectBtn.gameObject.SetActive(true);
                            DirObjectBtn.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1) + ". " + InteractObj.InteractOptions[i].DirText;

                            DirObjectBtn.transform.GetComponent<SelectInteractBtn>().SetInteractResult(InteractObj.InteractOptions[i].InteractResult.isResult, InteractObj.InteractOptions[i].InteractResult.Chat, InteractObj.InteractOptions[i].InteractResult.Item, InteractObj.InteractOptions[i].InteractResult.Result, InteractObj.InteractOptions[i].InteractResult.Type);
                            if (UseObj.Contains(InteractObj.InteractOptions[i].InteractResult.Item) || UseObj.Count > 1 && InteractObj.InteractOptions[i].InteractResult.Type == InteractResult.ResultType.EquipInHand)
                            {
                                DirObjectBtn.interactable = false;
                            }
                            else
                            {
                                DirObjectBtn.interactable = true;
                            }

                            DirObjectBtn.transform.GetComponent<SelectInteractBtn>().isEnding = InteractObj.InteractOptions[i].isEnding;
                            DirObjectBtn.transform.GetComponent<SelectInteractBtn>().EndingNumber = InteractObj.InteractOptions[i].EndingNumber;
                        }
                    }
                    else
                    {
                        DirObjectBtn.gameObject.SetActive(true);
                        DirObjectBtn.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1) + ". " + InteractObj.InteractOptions[i].DirText;

                        DirObjectBtn.transform.GetComponent<SelectInteractBtn>().SetInteractResult(InteractObj.InteractOptions[i].InteractResult.isResult, InteractObj.InteractOptions[i].InteractResult.Chat, InteractObj.InteractOptions[i].InteractResult.Item, InteractObj.InteractOptions[i].InteractResult.Result, InteractObj.InteractOptions[i].InteractResult.Type);
                        if (UseObj.Contains(InteractObj.InteractOptions[i].InteractResult.Item) || UseObj.Count > 1 && InteractObj.InteractOptions[i].InteractResult.Type == InteractResult.ResultType.EquipInHand)
                        {
                            DirObjectBtn.interactable = false;
                        }
                        else
                        {
                            DirObjectBtn.interactable = true;
                        }

                        DirObjectBtn.transform.GetComponent<SelectInteractBtn>().isEnding = InteractObj.InteractOptions[i].isEnding;
                        DirObjectBtn.transform.GetComponent<SelectInteractBtn>().EndingNumber = InteractObj.InteractOptions[i].EndingNumber;
                    }
                }
            }
        }
    }
}
