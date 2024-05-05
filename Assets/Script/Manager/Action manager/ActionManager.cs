using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionManager : MonoBehaviour
{
    public Transform content;
    public GameObject actionText;
    public List<GameObject> actionTextSoFar;

    public void SpawnText(Component component, object obj) {
        object[] temp = (object[]) obj;
        GameObject spawnedActionText = Instantiate(actionText, content);
        actionTextSoFar.Add(spawnedActionText);
        spawnedActionText.GetComponent<TextMeshProUGUI>().text = (string) temp[0];
        spawnedActionText.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 100);
        Debug.Log(actionTextSoFar.Count);
        if (actionTextSoFar.Count >= 10) {
            for (int i = 0; i < 5; i++) {
                Destroy(actionTextSoFar[0]);
                actionTextSoFar.Remove(actionTextSoFar[0]);
            }
        }
    }
}
