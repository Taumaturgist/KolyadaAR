using System;
using System.Collections;
using ARCarols.Scripts.UI.Enum;
using ARCarols.Scripts.UI.Overlay;
using PanelManager.Scripts;
using UnityEngine;

namespace Screenshoter
{
    public class ScreenshotManager : MonoBehaviour
    {
        [SerializeField] private Camera _targetCamera;

        private const string SCREENSHOT_FOLDER = "AR Коляда";

        private PanelManagerBase _panelManager;

        public void Init(PanelManagerBase panelManagerBase)
        {
            _panelManager = panelManagerBase;
        }
        
        public void TakeScreen()
        {
            StartCoroutine(TakeScreenshotCoroutine());
            
            _panelManager.OpenPanel<AppNotificationAnimatedView, PopupEnum>(PopupEnum.CompleteSave);
        }

        private IEnumerator TakeScreenshotCoroutine()
        {
            // Ожидаем один кадр для обновления отрисовки
            yield return new WaitForEndOfFrame();

            int width = Screen.width;

            int height = Screen.height;

            RenderTexture rt = new RenderTexture(width, height, 24);

            _targetCamera.targetTexture = rt;

            // The Render Texture in RenderTexture.active is the one
            // that will be read by ReadPixels.
            var currentRT = RenderTexture.active;

            RenderTexture.active = rt;

            // Render the camera's view.
            _targetCamera.Render();

            // Make a new texture and read the active Render Texture into it.
            Texture2D image = new Texture2D(width, height);

            image.ReadPixels(new Rect(0, 0, width, height), 0, 0);

            image.Apply();

            _targetCamera.targetTexture = null;

            // Replace the original active Render Texture.
            RenderTexture.active = currentRT;

            byte[] bytes = image.EncodeToPNG();

            string fileName = DateTime.Now.ToString("yyyy.MM.dd_HHmmss") + ".png";

            NativeGallery.SaveImageToGallery(bytes, SCREENSHOT_FOLDER, fileName);

            Destroy(rt);

            Destroy(image);
        }
    }
}