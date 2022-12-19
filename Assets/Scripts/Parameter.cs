using UnityEngine;
using UnityEngine.UI;

public class Parameter : MonoBehaviour
{
    [SerializeField] Text paramter;
    [SerializeField] Text value;

    public void InitializeParameter(Element.Pair pair)
    {
        paramter.text = pair.parameter;
        value.text = pair.value;
    }
}
