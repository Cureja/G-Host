using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public Sprite[] images;
    public SpriteRenderer img; 
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        img.sprite = images[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            index++;
            img.sprite = images[index];
        }
    }
}
