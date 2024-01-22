using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseText : SaiMonoBehaviour
{
    [Header("Base Text")]
    [SerializeField] protected Text text;

    public Text Text => text;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }

    protected virtual void LoadText()
    {
        this.text = GetComponent<Text>();
    }

}