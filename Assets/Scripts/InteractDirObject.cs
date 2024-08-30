using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct InteractOptions
{
    public string[] Conditions;
    public string Result;
};

public class InteractDirObject : MonoBehaviour
{
    public string ObjText;

    [SerializeField]
    InteractOptions[] InteractOptions;
   
    void Start()
    {
        
    }
}