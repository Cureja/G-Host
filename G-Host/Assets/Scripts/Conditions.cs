using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions : MonoBehaviour
{
    public static Conditions conditions;
    public bool possessed = false;
    public bool isCat = false;
    public Vector3 playerloc;
    //public static int catsPetted =0;
    public bool[] npcIsDazed;

    public bool[] cutscenes = new bool[3];
    //
    // public bool grandma = false;
    // public bool pond = false;
    // end

    public Sprite[] icons;

    void Awake()
    {
        if(conditions != null)
            GameObject.Destroy(conditions);
        else
            conditions = this;
        
        DontDestroyOnLoad(this);
    }
}
