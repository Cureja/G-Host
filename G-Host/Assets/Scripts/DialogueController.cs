using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class dialogueStruct
{
    public int sprite;
    public string nameText;
    public string bodyText;
    public dialogueStruct(int s, string name, string body)
    {
        sprite = s;
        nameText = name;
        bodyText = body;
    }
}

public class DialogueController : MonoBehaviour
{
    public SpriteRenderer profile_icon;
    public UnityEngine.UI.Text nameText;
    public UnityEngine.UI.Text bodyText;

    public PlayerController player;
    public Sprite[] icons;
    
    public bool isActive = false;
    private List<dialogueStruct> currentScript = new List<dialogueStruct>();
    private int index;
    public GameObject active;
    // Start is called before the first frame update
    void Start()
    {

        // List<dialogueStruct> a = new List<dialogueStruct>();
        // a.Add(new dialogueStruct(0, "adf", "wow hi"));
        // a.Add(new dialogueStruct(0, "bob", "yo whats up"));
        // a.Add(new dialogueStruct(0, "adf", "yo fsadfaksdfjk up"));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && isActive)
        {
            NextDialogue();
        }
    }

    public void LoadDialogue(List<dialogueStruct> toLoad) {
        active.SetActive(true);
        currentScript = toLoad;
        isActive = true;
        NextDialogue();
    }

    void NextDialogue(){
        if(index < currentScript.Count) {
            UpdateDialogue(currentScript[index]);
            index++;
        } else {
            active.SetActive(false);
            currentScript = new List<dialogueStruct>();
            player.exitedDialogue = true;
            isActive = false;
            index = 0;
        }
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
