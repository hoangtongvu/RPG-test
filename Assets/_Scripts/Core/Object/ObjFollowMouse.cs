using Core;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Core.Object
{
    public class ObjFollowMouse : ObjFollowTargetPos
    {
        protected override Vector3 GetTargetPos()
        {
            //Camera mainCam = MyCamera.CameraHolder.Instance.MainCam;

            //Vector3 mousePos = InputManager.Instance.MouseWorldPos;

            //Vector3 screenPos = mainCam.WorldToScreenPoint(transform.parent.position);
            //Debug.Log(screenPos);
            //Vector3 mouseScreenPos = Input.mousePosition;

            //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main.WorldToScreenPoint(transform.parent.position);

            //Get the Screen position of the mouse
            Vector2 mouseOnScreen = Input.mousePosition;

            Vector2 lookDir = mouseOnScreen - positionOnScreen;
            

            //Get the angle between the points
            float angle = Vector2.Angle(Vector2.up, lookDir);
            Debug.Log(angle);

            //Ta Daaa
            transform.parent.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));

            return InputManager.Instance.MouseWorldPos;
        }
    }
}