using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "BookSO", menuName = "Collectibles/Books", order = 1)]
public class BookSO : ScriptableObject
{
    public Sprite bookIcon;
    [TextAreaAttribute]
    public string title;
    [TextAreaAttribute]
    public string storyText;

    public void SetInfo(Image bookIconUI, TextMeshProUGUI bookTitile) {
        bookIconUI.sprite = bookIcon;
        bookTitile.text = title;
    }

    public void SetIconAndStoryText(Image bookIconUI, TextMeshProUGUI bookContent) {
        bookIconUI.sprite = bookIcon;
        bookContent.text = storyText;
    }
}
