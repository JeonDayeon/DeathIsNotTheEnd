using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct InteractOption
{
    public string[] Conditions; //2개까지만 가능하도록
    public string DirText;

    public InteractResult InteractResult;

    public bool isEnding;
    public int EndingNumber;
}

[System.Serializable]
public struct InteractResult
{
    [System.Serializable]
    public enum ResultType
    {
        None,
        EquipInHand,
        OnceChatBalloon,
        LoopChatBalloon
    }

    public ResultType Type;
    public string Item;
    public string Chat;
    public bool isResult;
    public string Result;
}

public class InteractDirObject : MonoBehaviour
{
    public string ObjText;

    [SerializeField]
    public List<InteractOption> InteractOptions;
}