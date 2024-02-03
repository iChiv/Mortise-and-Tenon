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

            // �洢ƫ���� = ��Ϸ������������ - �����������
            mOffset = gameObject.transform.position - GetMouseWorldPos();
        }

        private Vector3 GetMouseWorldPos()
        {
            // ��������(x,y)
            Vector3 mousePoint = Input.mousePosition;

            // z���� = ��Ϸ�����������ľ���
            mousePoint.z = mZCoord;

            return Camera.main.ScreenToWorldPoint(mousePoint);
        }

        void OnMouseDrag()
        {
            transform.position = GetMouseWorldPos() + mOffset;
        }
    }
}
