using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OneTimeObjectSO", menuName = "One time ObjectSO", order = 1)]
public class OneTimeObjectSO : ScriptableObject
{
    public bool complete = false;

    public void CheckIfComplete(OneTimeObject originalObject, List<GameObject> associatedObject) {
        if (complete) {
            Destroy(originalObject.gameObject);
            foreach (GameObject gameObject in associatedObject)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetComplete() {
        complete = true;
    }
}
