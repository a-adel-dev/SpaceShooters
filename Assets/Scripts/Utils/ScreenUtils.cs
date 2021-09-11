
using UnityEngine;

namespace Utils
{
    public static class ScreenUtils
    {
        private static int _screenWidth;
        private static int _screenHeight;

        private static float _screenLeft;
        private static float _screenRight;
        private static float _screenTop;
        private static float _screenBottom;

        public static float ScreenLeft
        {
            get
            {
                CheckScreenSizeChanged();
                return _screenLeft;
            }
        }

        public static float ScreenRight
        {
            get
            {
                CheckScreenSizeChanged();
                return _screenRight;
            }
        }

        public static float ScreenTop
        {
            get
            {
                CheckScreenSizeChanged();
                return _screenTop;
            }
        }

        public static float ScreenBottom
        {
            get
            {
                CheckScreenSizeChanged();
                return _screenBottom;
            }
        }

        private static void Initialize()
        {
            _screenWidth = Screen.width;
            _screenHeight = Screen.height;

            if (Camera.main is null) return;
            float screenZ = -Camera.main.transform.position.z;
            Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
            Vector3 upperRightCornerScreen = new Vector3(_screenWidth, _screenHeight, screenZ);

            Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
            Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);

            _screenLeft = lowerLeftCornerWorld.x;
            _screenRight = upperRightCornerWorld.x;
            _screenTop = upperRightCornerWorld.y;
            _screenBottom = lowerLeftCornerWorld.y;
        }

        private static void CheckScreenSizeChanged()
        {
            if (_screenWidth != Screen.width || _screenHeight != Screen.height)
            {
                Initialize();
            }
        }
    }
}
