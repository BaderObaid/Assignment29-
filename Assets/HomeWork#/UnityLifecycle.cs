using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment29
{
    public class UnitySpecificScript : MonoBehaviour
    {
        private GameObject targetObject;
        private GameObject jokerObject;

        void OnEnable() => print("GameObject Enabled");
        void Start()
        {
            print("Game started!");

            targetObject = GameObject.Find("TargetObject");
            jokerObject = GameObject.FindGameObjectWithTag("Joker");

            print(targetObject ? $"Found object by name: {targetObject.name}" : "No TargetObject found.");
           print(jokerObject ? $"Found object by tag: {jokerObject.name}" : "No Joker object found.");

            var light = GameObject.FindObjectOfType<Light>();
            print(light ? $"Found object of type Light: {light.name}" : "No Light object found.");
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                targetObject?.SetActive(false);
                print("TargetObject deactivated!");
            }
        }
        void OnDisable() => print("GameObject Disabled");
    }
}
