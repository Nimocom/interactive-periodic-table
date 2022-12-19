using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Title : MonoBehaviour
{
    [SerializeField] Text titleName;

    public void InitializeTitle(Element.Title title)
    {
        titleName.text = title.titleName;

        for (int i = 0; i < title.pairs.Count; i++)
            Instantiate(SidePanel.inst.parameterPrefab, transform).InitializeParameter(title.pairs[i]);
    }
}
