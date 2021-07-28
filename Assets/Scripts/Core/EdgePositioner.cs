using UnityEngine;
using Utils;

namespace Core
{
    public class EdgePositioner : MonoBehaviour
    {
        private void Update()
        {
            HandleEdgePosition();
        }
        
        private void HandleEdgePosition()
        {
            if (transform.position.x > ScreenUtils.ScreenRight)
            {
                transform.position = new Vector3(ScreenUtils.ScreenLeft, transform.position.y, transform.position.z);
            }

            if (transform.position.x < ScreenUtils.ScreenLeft)
            {
                transform.position = new Vector3(ScreenUtils.ScreenRight, transform.position.y, transform.position.z);
            }

            if (transform.position.y > ScreenUtils.ScreenTop)
            {
                transform.position = new Vector3(transform.position.x, ScreenUtils.ScreenBottom, transform.position.z);
            }

            if (transform.position.y < ScreenUtils.ScreenBottom)
            {
                transform.position = new Vector3(transform.position.x, ScreenUtils.ScreenTop, transform.position.z);
            }
        }
    }
}