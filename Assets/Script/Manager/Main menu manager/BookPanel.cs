using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BookPanel : MonoBehaviour
{
    public Image bookIcon;
    public TextMeshProUGUI bookTitle;
    public CrossObjectEventWithData broadcastBookInfo;
    private BookSO bookSO;

    public void SetInfo(BookSO bookSO) {
        this.bookSO = bookSO;
        this.bookSO.SetInfo(bookIcon, bookTitle);
    }

    public void BroadcastBookInfo() {
        broadcastBookInfo.TriggerEvent(this, bookSO);
    }
}
