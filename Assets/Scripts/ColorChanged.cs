using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanged : MonoBehaviour
{
    public Color[] colors;
    Color firstColor, secondColor;
    int firstIndex;
    public Material groundMat;
    void Start()
    {
        firstIndex = Random.Range(0, colors.Length);
        secondColor = colors[SecondColor()];
        groundMat.color = colors[firstIndex];
        Camera.main.backgroundColor = colors[firstIndex];
    }
    private void Update()
    {
        Color diffrent = groundMat.color - secondColor;

        if (Mathf.Abs(diffrent.r) + Mathf.Abs(diffrent.g) + Mathf.Abs(diffrent.b) <.2f)
        {
            secondColor = colors[SecondColor()];
        }
        groundMat.color = Color.Lerp(groundMat.color, secondColor, Time.deltaTime * .5f);
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, secondColor, Time.deltaTime * .2f);
    }
    int SecondColor()
    {
        int secondColorIndex;
        secondColorIndex = Random.Range(0, colors.Length);

        while (secondColorIndex == firstIndex)
        {
            secondColorIndex = Random.Range(0, colors.Length);
        }
        return secondColorIndex;
    }
}
