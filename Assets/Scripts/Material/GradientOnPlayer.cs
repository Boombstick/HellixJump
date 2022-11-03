using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradientOnPlayer : MonoBehaviour
{
    public Material DissolveMaterial;
    public Slider Slider;


    private void Update()
    {
        DissolveMaterial.SetFloat("_Edge2",Slider.value);

    }
}
