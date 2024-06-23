using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FriendshipEnlargedPanel : MonoBehaviour
{
    public Image enlargedObjectOfFaith;
    public TextMeshProUGUI oofName;
    public TextMeshProUGUI oofDescriptiob;
    
    public void SetInfo(Component component, object obj) {
        object[] temp = (object[]) obj;
        PlayerSO playerSO = (PlayerSO) temp[0];
        playerSO.SetOOFInfo(enlargedObjectOfFaith, oofName, oofDescriptiob);
    }
}
