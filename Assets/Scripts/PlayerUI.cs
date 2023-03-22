using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI speedText;
    [SerializeField]
    public TextMeshProUGUI boostText;
    private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = body.velocity.magnitude;
        speedText.text = "Vitesse : " + speed.ToString("F2");
    }

    public void ShowBoost()
    {
        StartCoroutine(FadeOutText(boostText));
    }

    
    private IEnumerator FadeOutText(TextMeshProUGUI text)
    {
        Color originalColor = text.color;
        float alpha = 1f;

        // Set the alpha value of the text to 1 (100%)
        originalColor.a = alpha;
        text.color = originalColor;

        // Gradually decrease the alpha value over a period of three seconds
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime / 2f;
            originalColor.a = alpha;
            text.color = originalColor;
            yield return null;
        }

    }
}
