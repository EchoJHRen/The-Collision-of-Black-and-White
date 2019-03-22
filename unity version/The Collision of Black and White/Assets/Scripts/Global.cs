using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

    private static Global instance;
    public static Global GetInstance()
    {
        if (instance == null)
        {
            instance = new Global();
        }
        return instance;
    }
    public string loadName1 = "Level1";
    public string loadName2 = "Level2";

}
