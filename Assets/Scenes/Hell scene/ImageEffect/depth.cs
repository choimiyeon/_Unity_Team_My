using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellCameraEffect : MonoBehaviour
{
    Material myMaterial;
    Shader myShader;

    void Start()
    {
        myShader = Shader.Find("My/PostEffects/depth");
        myMaterial = new Material(myShader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, myMaterial, 0);
    }

    private void onDisable()
    {
        if (myMaterial)
        {
            DestroyImmediate(myMaterial);
        }
    }

}
