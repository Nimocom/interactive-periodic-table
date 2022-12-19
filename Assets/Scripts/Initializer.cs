using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text;

public class Initializer : MonoBehaviour
{
    [SerializeField] Element[] elementsArray;

    [SerializeField] Transform elementsRoot;

    [SerializeField] Sprite defaultIcon;

    [Serializable]
    class TotalData
    {
        public List<Element.Data> dataList;
    }

    [SerializeField] TotalData totalData;

    private void Awake()
    {

        totalData = JsonUtility.FromJson<TotalData>(File.ReadAllText(Application.streamingAssetsPath + "/TotalData.txt", Encoding.UTF8));

        for (int i = 0; i < 126; i++)
        {
            for (int j = 0; j < 126; j++)
            {
                if (totalData.dataList[j].number == elementsArray[i].number)
                {
                    elementsArray[i].data = totalData.dataList[j];
                    elementsArray[i].data.icon = defaultIcon;
                    break;
                }
            }
          
        }
    }
}
