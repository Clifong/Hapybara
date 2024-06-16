using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUIInfo : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;
    public Transform rewardContent;
    public GameObject rewardIcon;
    [SerializeField]
    private QuestSO questSO;
    private List<GameObject> rewardIconList = new List<GameObject>();

    public void SetInfo(Component component, object obj) {
        object[] temp = (object[]) obj;
        this.questSO = (QuestSO) temp[0];
        foreach (GameObject icon in rewardIconList)
        {
            Destroy(icon);
        }
        rewardIconList.Clear();
        questSO.SetInfo(name, description, rewardContent, rewardIcon, rewardIconList);
    }
}
