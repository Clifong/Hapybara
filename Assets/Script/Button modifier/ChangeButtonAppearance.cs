using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ChangeButtonAppearance : MonoBehaviour
{
    public Image buttonImage;
    public Sprite before;
    public Sprite after;
    private bool pressed;
    public UnityEvent buttonNotPressedEvent;
    public UnityEvent buttonPressedEvent;

    // Start is called before the first frame update
    void OnEnable()
    {
        buttonImage.sprite = before;
        pressed = false;
    }

    public void Pressed() {
        pressed = !pressed;
        if (pressed) {
            buttonImage.sprite = after;
            buttonPressedEvent?.Invoke();
        } else {
            buttonImage.sprite = before;
            buttonNotPressedEvent?.Invoke();
        }
    }

}
