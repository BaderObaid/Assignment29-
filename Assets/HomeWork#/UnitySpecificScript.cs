using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment29
{
    public class UnityLifecycle : MonoBehaviour
    {
        private GameObject targetObject;
        private GameObject jokerObject;

        void OnEnable() => Debug.Log("GameObject Enabled");
        void Start()
        {
            Debug.Log("Game started!");

            targetObject = GameObject.Find("TargetObject");
            jokerObject = GameObject.FindGameObjectWithTag("Joker");

            Debug.Log(targetObject ? $"Found object by name: {targetObject.name}" : "No TargetObject found.");
            Debug.Log(jokerObject ? $"Found object by tag: {jokerObject.name}" : "No Joker object found.");

            var light = GameObject.FindObjectOfType<Light>();
            Debug.Log(light ? $"Found object of type Light: {light.name}" : "No Light object found.");
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                targetObject?.SetActive(false);
                Debug.Log("TargetObject deactivated!");
            }
        }
        void OnDisable() => Debug.Log("GameObject Disabled");
    }
}
