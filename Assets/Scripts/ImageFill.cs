using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class ImageFill : MonoBehaviour
{
   
    [Tooltip("Value to use as the current ")]
    public IntVariable Variable;

    [Tooltip("Min value that Variable to have no fill on Image.")]
    public float Min;

    [Tooltip("Max value that Variable can be to fill Image.")]
    public IntVariable Max;

    [Tooltip("Image to set the fill amount on." )]
    public Image Image;

    private void Update()
    {
        Image.fillAmount = Mathf.Clamp01(
            Mathf.InverseLerp(Min, Max.Value, Variable.Value));
    }
}
