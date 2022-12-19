using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Element : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [System.Serializable]
    public struct Title
    {
        public string titleName;
        public List<Pair> pairs;
    }

    [System.Serializable]
    public struct Pair
    {
        public string parameter;
        public string value;
    }

    [System.Serializable]
    public struct Data
    {
        //public string imageUrl;
        public Sprite icon;
        public string description;
        public int number;
        public string symbol;
        public string name;
        public List<Title> titles;
    }

    public Data data;

    [SerializeField] Text elementSymbol;
    [SerializeField] Text elementName;
    [SerializeField] Text atomicNumber;

    public int number;

    void Start()
    {

        elementName.text = data.name;
        elementSymbol.text = data.symbol;
        atomicNumber.text = number.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundManager.inst.PlayOnMouseOverSound();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SidePanel.inst.ShowInfo(data);
    }
}
