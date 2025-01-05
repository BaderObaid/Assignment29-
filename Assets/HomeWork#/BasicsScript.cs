using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assignment29

{
    public class BasicsScript : MonoBehaviour
    {
        void Start()
        {
            
            var number = 5;
            var message = "The current number is";
            var boolLine = number % 2 == 0;

            
            string result = $"{message} {number} and it is {(boolLine ? "even" : "odd")}.";
            Debug.Log(result);

            
            Debug.Log($"Date: {DateTime.Now.ToShortDateString()}");
            Debug.Log($"Time: {DateTime.Now.ToLongTimeString()}");
            Debug.Log($"Day: {DateTime.Now.DayOfWeek}");
        }
    }
}