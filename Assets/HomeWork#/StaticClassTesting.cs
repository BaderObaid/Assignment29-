using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assignment29
{

public class StaticClassTesting : MonoBehaviour
{
        void Start()
        {
            Debug.Log($"Sum: {Utilities.Add(1, 2, 3, 4, 5)}");

            
            string repeated = "Helloooo".RepeatString(3); // the return on the console is Hel only 
            Debug.Log(repeated);
        }
    }
}

