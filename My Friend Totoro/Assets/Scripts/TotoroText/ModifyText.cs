using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ModifyText : MonoBehaviour
{
    private XRSimpleInteractable interactable;
    public TextMeshProUGUI bubbleText;
    public Image bubble;


    private void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();


        interactable.selectEntered.AddListener(OnGrabbed);

    }

    private void OnGrabbed(SelectEnterEventArgs arg0)
    {
        string example = "This is an example text";
        bubbleText.text = example;
        FitText(example);
    }

    private void FitText(string text) {
        RectTransform imageRect = bubble.rectTransform;

        float maxWidth = imageRect.rect.width;
        bubbleText.fontSize = Mathf.FloorToInt(bubbleText.fontSize * maxWidth / bubbleText.rectTransform.rect.width);
    }

    private void CenterText() {
        RectTransform imageRect = bubble.rectTransform;
        RectTransform textRect = bubbleText.rectTransform;

        textRect.anchorMin = new Vector2(0.5f, 0.5f);
        textRect.anchorMax = new Vector2(0.5f, 0.5f);
        textRect.pivot = new Vector2(0.5f, 0.5f);

        Vector2 centerPosition = new Vector2(imageRect.rect.width * 0.5f, imageRect.rect.height * 0.5f);

        textRect.localPosition = centerPosition;
    }
}
