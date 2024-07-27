using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
// other code, class definition blah blah


public abstract class OneTimeObject : MonoBehaviour
{
    public OneTimeObjectSO onetimeObjectSO;
    public List<GameObject> associatedObject = new List<GameObject>();

    protected void Start() {
        onetimeObjectSO.CheckIfComplete(this, associatedObject);
    }

    protected virtual void SetComplete() {
        onetimeObjectSO.SetComplete();
        onetimeObjectSO.SetDirty();
        Destroy(this.gameObject);
    }
}
