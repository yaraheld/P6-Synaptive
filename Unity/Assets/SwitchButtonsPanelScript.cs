using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtonsPanelScript : MonoBehaviour
{
    private Button[] buttons;

    private void Start()
    {
        // Holen Sie sich alle Buttons im aktuellen GameObject und seinen Kindern.
        buttons = GetComponentsInChildren<Button>();

        // Fügen Sie jedem Button einen Listener hinzu, der auf ButtonClick aufgerufen wird.
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClicked(button));
        }
    }

    private void OnButtonClicked(Button clickedButton)
    {
        // Wenn der geklickte Button interaktiv ist, ändern Sie seinen Zustand auf nicht interaktiv, sonst setzen Sie ihn auf interaktiv.
        clickedButton.interactable = !clickedButton.interactable;
    }
}