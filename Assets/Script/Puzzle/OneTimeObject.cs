using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class OneTimeObject : MonoBehaviour
{
    public OneTimeObjectSO onetimeObjectSO;
    public List<GameObject> associatedObject;

    protected void Start() {
        onetimeObjectSO.CheckIfComplete(this, associatedObject);
    }

    protected virtual void SetComplete() {
        onetimeObjectSO.SetComplete();
        EditorUtility.SetDirty(onetimeObjectSO);
        Destroy(this.gameObject);
    }
}
