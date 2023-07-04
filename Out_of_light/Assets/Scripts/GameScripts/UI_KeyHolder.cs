using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_KeyHolder : MonoBehaviour
{
    [SerializeField] private KeyHolder keyHolder;
    [SerializeField] private GameObject keyTamplate;
    private Transform container;

    private void Awake()
    {
        container = transform.Find("container");
    }

    private void Start()
    {
        keyHolder.OnKeyChanged += KeyHolder_OnKeysChanged;
    }

    private void KeyHolder_OnKeysChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    private void UpdateVisual()
    {
        // delete old key
        foreach(Transform child in container)
        {
            if (child == keyTamplate) continue;
            Destroy(child.gameObject);
        }

        // Instantiate key
        List<Key.KeyType> keys = keyHolder.GetKeys();
        for (int i = 0; i < keys.Count; i++)
        {
            Key.KeyType key = keys[i];
            Transform keyTransform = Instantiate(keyTamplate.transform, container);
            keyTransform.gameObject.SetActive(true);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 * i, 0);
            Image keyImage = keyTransform.Find("Image").GetComponent<Image>();
            //Red, Green, Blue, Orange, Purple, Brown, Yellow, Pink, White, Gray
            switch (key)
            {
                default:
                case Key.KeyType.Red: keyImage.color = Color.red; break;

                case Key.KeyType.Green: keyImage.color = Color.green; break;

                case Key.KeyType.Blue: keyImage.color = new Color(0f, 0.63f, 1f); break;

                case Key.KeyType.Orange: keyImage.color = new Color(1, 0.6f, 0); break;

                case Key.KeyType.Purple: keyImage.color = new Color(0.63f, 0.21f, 0.65f); break;

                case Key.KeyType.Brown: keyImage.color = new Color(0.4f, 0.3f, 0.1f); break;

                case Key.KeyType.Yellow: keyImage.color = Color.yellow; break;

                case Key.KeyType.Pink: keyImage.color = Color.magenta; break;

                case Key.KeyType.White: keyImage.color = Color.white; break;

                case Key.KeyType.Gray: keyImage.color = Color.gray; break;
            }
        }
    }
}
