using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InventoryIcon : MonoBehaviour
{
    public Image icon;
    public CrossObjectEventWithData broadcastInventorySO;
}
