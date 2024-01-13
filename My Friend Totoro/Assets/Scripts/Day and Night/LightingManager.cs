using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset preset;

    [SerializeField, Range(0, 24)] public float TimeOfDay;

    private void Update()
    {
        if (preset == null) {
            return;
        }

        
          UpdateLighting(TimeOfDay / 24f);

    }

    private void UpdateLighting(float timePercent) {
        RenderSettings.ambientLight = preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.FogColor.Evaluate(timePercent);

        if (directionalLight != null) { 
            directionalLight.color = preset.DirectionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }

    private void OnValidate()
    {
        if (directionalLight != null) {
            return;
        }

        if (RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights) {
                if (light.type == LightType.Directional) {
                    directionalLight = light;
                    return;
                }
            }
        }

    }
}