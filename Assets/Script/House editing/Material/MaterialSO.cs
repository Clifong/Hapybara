using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialSO", menuName = "MaterialSO", order = 1)]
public class MaterialSO : ScriptableObject
{
    [Header("Information")]
    public Sprite materialIcon;
    public string materialName;
    [TextAreaAttribute]
    public string materialDescription;
}
