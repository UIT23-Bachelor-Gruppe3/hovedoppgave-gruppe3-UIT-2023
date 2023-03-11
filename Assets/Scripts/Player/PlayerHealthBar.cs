using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [Tooltip("Value to use as the current ")]
    public FloatReference Variable;

    [Tooltip("Min value that Variable to have no fill on Image.")]
    public FloatReference Min;

    [Tooltip("Max value that Variable can be to fill Image.")]
    public FloatReference Max;

    [Tooltip("Image to set the fill amount on.")]
    public Image Image;

    private void Update()
    {
        Image.fillAmount = Mathf.Clamp01(
            Mathf.InverseLerp(Min, Max, Variable));
    }
}
