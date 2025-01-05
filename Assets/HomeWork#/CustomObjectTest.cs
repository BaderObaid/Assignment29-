using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment29
{


    public class CustomObjectTest : MonoBehaviour
    {
        void Start()
        {
            var obj = new CustomObject(1, "Example");
            Debug.Log(obj);

            var obj2 = new CustomObject(2, "Test");
            Debug.Log(obj == obj2);
            Debug.Log(obj != obj2);
        }
    }
}


