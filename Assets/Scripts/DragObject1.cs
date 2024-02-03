using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject1 : MonoBehaviour
{
    public class DragObject : MonoBehaviour
    {
        private Vector3 mOffset;
        private float mZCoord;

        void OnMouseDown()
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

            // 存储偏移量 = 游戏对象世界坐标 - 鼠标世界坐标
            mOffset = gameObject.transform.position - GetMouseWorldPos();
        }

        private Vector3 GetMouseWorldPos()
        {
            // 像素坐标(x,y)
            Vector3 mousePoint = Input.mousePosition;

            // z坐标 = 游戏对象距离相机的距离
            mousePoint.z = mZCoord;

            return Camera.main.ScreenToWorldPoint(mousePoint);
        }

        void OnMouseDrag()
        {
            transform.position = GetMouseWorldPos() + mOffset;
        }
    }
}
