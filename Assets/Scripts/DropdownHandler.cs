using System;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    public Dropdown ddPlayers, ddSpeed, ddBackground;

    void Start()
    {
        ValuesChanged();
    }

    public void ValuesChanged()
    {
        GameOptions.NumberOfPlayers = Convert.ToInt32(ddPlayers.options[ddPlayers.value].text);
        GameOptions.InitialSpeed = ddSpeed.options[ddSpeed.value].text;
        GameOptions.Background = ddBackground.options[ddBackground.value].text;
    }
}
