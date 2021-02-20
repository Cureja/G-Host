using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct dialogueStruct
{
    public dialogueStruct(int s, string name, string body)
    {
        sprite = s;
        nameText = name;
        bodyText = body;
    }

    public int sprite{ get; }
    public string nameText { get; }
    public string bodyText { get; }

    public override string ToString()  => $"({sprite}, {nameText})";
}

public class DialogueController : MonoBehaviour
{
    public SpriteRenderer profile_icon;
    public UnityEngine.UI.Text nameText;
    public UnityEngine.UI.Text bodyText;

    public PlayerController player;
    public Sprite[] icons;
    
    private List<dialogueStruct> currentScript;

    // Start is called before the first frame update
    void Start()
    {
        List<dialogueStruct> a = new List<dialogueStruct>();
        a.Add(new dialogueStruct(0, "adf", "wow hi"));
        a.Add(new dialogueStruct(0, "bob", "yo whats up"));
        a.Add(new dialogueStruct(0, "adf", "yo fsadfaksdfjk up"));
        currentScript = a;
    }

    // Update is called once per frame
    void Update()
    {
        // if(active) {
            if(Input.GetKeyDown("space"))
            {
                if(currentScript.Count != 0) {
                    UpdateDialogue(currentScript[0]);
                    currentScript.RemoveAt(0);
                } else {
                    gameObject.SetActive(false);
                }
            }
        // }
        
    }

    void LoadDialogue(List<dialogueStruct> toLoad) {
        gameObject.SetActive(true);
        currentScript = toLoad;
    }

    void UpdateDialogue(int sprite, string name, string body) {
        profile_icon.sprite = icons[sprite];
        nameText.text = name;
        bodyText.text = body;
    }
    void UpdateDialogue(dialogueStruct d) {
        profile_icon.sprite = icons[d.sprite];
        nameText.text = d.nameText;
        bodyText.text = d.bodyText;
    }
}
