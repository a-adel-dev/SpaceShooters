
using UnityEngine;

namespace Utils
{
    public static class ScreenUtils
    {
        private static int screenWidth;
        private static int screenHeight;

        private static float screenLeft;
        private static float screenRight;
        private static float screenTop;
        private static float screenBottom;

        public static float ScreenLeft
        {
            get
            {
                CheckScreenSizeChanged();
                return screenLeft;
            }
        }

        public static float ScreenRight
        {
            get
            {
                CheckScreenSizeChanged();
                return screenRight;
            }
        }

        public static float ScreenTop
        {
            get
            {
                CheckScreenSizeChanged();
                return screenTop;
            }
        }

        public static float ScreenBottom
        {
            get
            {
                CheckScreenSizeChanged();
                return screenBottom;
            }
        }

        private static void Initialize()
        {
            screenWidth = Screen.width;
            screenHeight = Screen.height;

            if (Camera.main is null) return;
            float screenZ = -Camera.main.transform.position.z;
            Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
            Vector3 upperRightCornerScreen = new Vector3(screenWidth, screenHeight, screenZ);

            Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
            Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);

            screenLeft = lowerLeftCornerWorld.x;
            screenRight = upperRightCornerWorld.x;
            screenTop = upperRightCornerWorld.y;
            screenBottom = lowerLeftCornerWorld.y;
        }

        private static void CheckScreenSizeChanged()
        {
            if (screenWidth != Screen.width || screenHeight != Screen.height)
            {
                Initialize();
            }
        }
    }
}
