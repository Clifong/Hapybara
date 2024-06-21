using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OneTimeObject : MonoBehaviour
{
    public OneTimeObjectSO onetimeObjectSO;
    public List<GameObject> associatedObject;

    protected void Start() {
        onetimeObjectSO.CheckIfComplete(this, associatedObject);
    }

    protected void SetComplete() {
        Destroy(this.gameObject);
        onetimeObjectSO.SetComplete();
    }
}
