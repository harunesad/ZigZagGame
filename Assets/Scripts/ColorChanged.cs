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
        groundMat.color = colors[firstIndex];
        Camera.main.backgroundColor = colors[firstIndex];
    }
    void Update()
    {
        
    }
}
