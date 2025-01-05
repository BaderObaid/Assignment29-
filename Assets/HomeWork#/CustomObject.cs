using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assignment29
{
    public class CustomObject
    {

        
        public int ID { get; set; }
        public string Name { get; set; }

        
        public CustomObject(int id, string name)
        {
            ID = id;
            Name = name;
        }

                public override string ToString()
        {
            return "Object [ID: " + ID + ", Name: " + Name + "]";
        }
    }

}