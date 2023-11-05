using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotTest : MonoBehaviour
{
    [SerializeField] private Button _button;

    [SerializeField] private Camera _targetCamera;

    private const string SCREENSHOT_FOLDER = "AR Коляда";

    private void Awake()
    {
        _button.onClick.AddListener(TakeScreen);
    }

    private IEnumerator TakeScreenshotCoroutine()
    {
        // Ожидаем один кадр для обновления отрисовки
        yield return new WaitForEndOfFrame();

        Camera camera = _targetCamera;

        int width = Screen.width;

        int height = Screen.height;

        RenderTexture rt = new RenderTexture(width, height, 24);

        camera.targetTexture = rt;

        // The Render Texture in RenderTexture.active is the one
        // that will be read by ReadPixels.
        var currentRT = RenderTexture.active;

        RenderTexture.active = rt;

        // Render the camera's view.
        camera.Render();

        // Make a new texture and read the active Render Texture into it.
        Texture2D image = new Texture2D(width, height);

        image.ReadPixels(new Rect(0, 0, width, height), 0, 0);

        image.Apply();

        camera.targetTexture = null;

        // Replace the original active Render Texture.
        RenderTexture.active = currentRT;
        
        byte[] bytes = image.EncodeToPNG();

        string fileName = DateTime.Now.ToString("yyyy.MM.dd_HHmmss") + ".png";

        NativeGallery.SaveImageToGallery(bytes, SCREENSHOT_FOLDER, fileName);

        Destroy(rt);

        Destroy(image);
    }

    
    
    private void TakeScreen()
    {
        StartCoroutine(TakeScreenshotCoroutine());
    }
}