using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MMap : MonoBehaviour
{
    public Camera MinimapCamera; 
    public RawImage UiImage; 

    void Update()
    {
        RenderTexture renderTexture = MinimapCamera.targetTexture; 
        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);

        RenderTexture.active = renderTexture;
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture.Apply();
        RenderTexture.active = null;

        UiImage.texture = texture; 
    }
}

