using UnityEngine;
using UnityEngine.UI;

namespace MainCamera
{
    // Saving and modifying aspect ratio of a windowed game
    public class AspectRatioSaver : MonoBehaviour
    {
        [SerializeField] private CanvasScaler canvasScaler;

        private Camera _camera;
        private Rect _rect;
        private Vector2 _referenceResolution;


        private const float TargetAspectWidth = 16.0f;
        private const float TargetAspectHeight = 9.0f;


        private float _targetAspect;
        private float _currentAspect;

        // Vertical and horizontal scaling parameters are needed for resizing
        // and adjusting vertical and horizontal blackboxes  
        private float _scaleHeight;
        private float _scaleWidth;

        private void Start()
        {
            _camera = GetComponent<Camera>();

            _referenceResolution =
                new Vector2(Screen.width, Screen.height);
            AdjustCanvasScaler();
        }

        // CanvasScaler also needs to be adjusted because of UI scaling issues
        private void AdjustCanvasScaler()
        {
            float targetAspect = TargetAspectWidth / TargetAspectHeight;
            float currentAspect = (float)Screen.width / Screen.height;

            if (currentAspect >= targetAspect)
            {
                _referenceResolution.x = targetAspect * _referenceResolution.y;
            }
            else
            {
                _referenceResolution.y = _referenceResolution.x / targetAspect;
            }

            // TODO: Need to reference this differently since prefab can't load this object and build doesn;t work properly

            canvasScaler.referenceResolution = _referenceResolution;
        }

        private void LateUpdate()
        {
            SetCameraAspect_16x9();
        }

        void SetCameraAspect_16x9()
        {
            _targetAspect = TargetAspectWidth / TargetAspectHeight;


            _currentAspect = (float)Screen.width / (float)Screen.height;

            _scaleHeight = _currentAspect / _targetAspect;

            GenerateHorizontalBoxes();
            GenerateVerticalBoxes();
            AdjustCanvasScaler();
        }

        private void GenerateHorizontalBoxes()
        {
            if (_scaleHeight < 1.0f)
            {
                _rect = _camera.rect;

                _rect.width = 1f;
                _rect.height = _scaleHeight;
                _rect.x = 0f;

                _rect.y = (1f - _scaleHeight) / 2f;

                _camera.rect = _rect;
            }
        }

        private void GenerateVerticalBoxes()
        {
            if (_scaleHeight >= 1.0f)
            {
                _rect = _camera.rect;

                _scaleWidth = 1f / _scaleHeight;
                _rect.width = _scaleWidth;
                _rect.height = 1f;
                _rect.x = (1f - _scaleWidth) / 2f;
                _rect.y = 0f;

                _camera.rect = _rect;
            }
        }
    }
}