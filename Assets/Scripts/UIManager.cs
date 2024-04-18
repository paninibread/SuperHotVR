using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Light pLight;

    public Button red;
    public Button green;
    public Button blue;
    public Button yellow;

    public Slider slider;

    private static Button selectedButton;
    // Start is called before the first frame update
    void Start()
    {
        red.onClick.AddListener(delegate { pLight.color = new Color(0.929f, 0.769f, 0.847f, 1f); });
        green.onClick.AddListener(delegate { pLight.color = new Color(0.847f, 0.922f, 0.769f, 1f); });
        blue.onClick.AddListener(delegate { pLight.color = new Color(0.651f, 0.714f, 0.878f, 1f); });
        yellow.onClick.AddListener(delegate { pLight.color = new Color(0.91f, 0.886f, 0.439f, 1f); });

        slider.onValueChanged.AddListener(delegate { pLight.intensity = slider.value; });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
