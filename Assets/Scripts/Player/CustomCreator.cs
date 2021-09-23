using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomCreator : MonoBehaviour
{
    public Slider sliderval;
    public MeshRenderer _eyeRendererL = null;
    public MeshRenderer _eyeRendererR = null;

    // eye materials
    public Material complicatedEye01Material = null;
    public Material complicatedEye02Material = null;
    public Material complicatedEye03Material = null;
    public Material complicatedEye04Material = null;
    public Material complicatedEye05Material = null;
    public Material complicatedEye06Material = null;
    public Material complicatedEye07Material = null;

    private void Awake()
    {
        sliderval = GetComponent<Slider>();
        _eyeRendererL = GetComponent<MeshRenderer>();
        _eyeRendererR = GetComponent<MeshRenderer>();
    }

    public void customEye()
    {
        float valueSlider = sliderval.value;
        switch (valueSlider)
        {
            case 1:
                _eyeRendererL.material = complicatedEye01Material;
                _eyeRendererR.material = complicatedEye01Material;
                break;
            case 2:
                _eyeRendererL.material = complicatedEye02Material;
                _eyeRendererR.material = complicatedEye02Material;
                break;
            case 3:
                _eyeRendererL.material = complicatedEye03Material;
                _eyeRendererR.material = complicatedEye03Material;
                break;
            case 4:
                _eyeRendererL.material = complicatedEye04Material;
                _eyeRendererR.material = complicatedEye04Material;
                break;
            case 5:
                _eyeRendererL.material = complicatedEye05Material;
                _eyeRendererR.material = complicatedEye05Material;
                break;
            case 6:
                _eyeRendererL.material = complicatedEye06Material;
                _eyeRendererR.material = complicatedEye06Material;
                break;
            case 7:
                _eyeRendererL.material = complicatedEye07Material;
                _eyeRendererR.material = complicatedEye07Material;
                break;
        }
    }

    private void Update()
    {
        
    }
}
