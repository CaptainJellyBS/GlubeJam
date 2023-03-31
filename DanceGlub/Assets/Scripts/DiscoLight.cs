using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoLight : MonoBehaviour
{
    Light light;
    public Color[] colors;
    public float bpm = 130.0f;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        StartCoroutine(LightSwitchingC());
    }

    IEnumerator LightSwitchingC()
    {
        while (true)
        {
            Utility.FisherYates(ref colors);
            for (int i = 0; i < colors.Length; i++)
            {
                if(colors[i] == light.color) { continue; } //skip if the color is the same
                light.color = colors[i];
                yield return new WaitForSeconds(60.0f / bpm);
            }
        }
    }
}
