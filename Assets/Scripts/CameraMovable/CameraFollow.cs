using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraMovable
{
    public class CameraFollow : MonoBehaviour
    {
        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

    }

}