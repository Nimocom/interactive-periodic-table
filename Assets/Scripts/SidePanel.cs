using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class SidePanel : MonoBehaviour
{
    public static SidePanel inst;

    public Title titlePrefab;
    public Parameter parameterPrefab;

    [SerializeField] Image icon;

    [SerializeField] ScrollRect scrollRect;

    [SerializeField] Transform contentRoot;

    [SerializeField] Text descriptionPrefab;

    [SerializeField] Vector3 openedStatePosition;
    [SerializeField] Vector3 hiddenStatePosition;

    Coroutine coroutine;
    RectTransform rectTransform;

    private void Awake()
    {
        inst = this;
        rectTransform = GetComponent<RectTransform>();
    }


    public void ShowInfo(Element.Data data)
    {
        transform.localPosition = hiddenStatePosition;

        for (int i = 0; i < contentRoot.childCount; i++)
            Destroy(contentRoot.GetChild(i).gameObject);

        //for (int i = data.titles.Count-1; i >= 0; i--)
        for (int i = 0; i < data.titles.Count; i++)
            Instantiate(titlePrefab, contentRoot).InitializeTitle(data.titles[i]);

        Instantiate(descriptionPrefab, contentRoot).text = data.description;

        LayoutRebuilder.ForceRebuildLayoutImmediate(contentRoot.GetComponent<RectTransform>());

        icon.sprite = data.icon;

        scrollRect.verticalNormalizedPosition = 1f;

        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(LerpPosition());

        //if (!string.IsNullOrEmpty(data.imageUrl))
        //    StartCoroutine(DownloadImage(data.imageUrl));
    }

    IEnumerator LerpPosition()
    {
        while (rectTransform.localPosition != openedStatePosition)
        {
            rectTransform.localPosition = Vector3.Lerp(rectTransform.localPosition, openedStatePosition, 12f * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator DownloadImage(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
                yield break;

            var texture = DownloadHandlerTexture.GetContent(webRequest);
            var sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f);

            icon.sprite = sprite;
          
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
