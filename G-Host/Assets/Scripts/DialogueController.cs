using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public string scene;

    public bool isActive = false;
    public List<dialogueStruct> currentScript = new List<dialogueStruct>();
    public List<dialogueStruct> failedScript;
    public List<dialogueStruct> successScript;
    public bool isEnd = false;
    public bool cutscene = false;
    public int cutsceneid = -1;
    private int index = 0;
    public GameObject active;
    // Start is called before the first frame update
    void Start()
    {
        if(cutscene) {
            isActive = true;
            if(!isEnd) {
                if(Conditions.conditions.possessed) {
                    Conditions.conditions.cutscenes[cutsceneid] = true;
                    currentScript = successScript;
                    Conditions.conditions.possessed = false;
                    
                }
                else {
                    currentScript = failedScript;
                }
            } else {
                if(Conditions.conditions.isCat) {
                    currentScript = successScript;
                    
                }
                else {
                    currentScript = failedScript;
                }
            }
            NextDialogue();
        }
        
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
        } 
        else if (scene != ""){
            SceneManager.LoadScene(scene);
        } 
        else {
            active.SetActive(false);
            currentScript = new List<dialogueStruct>();
            player.exitedDialogue = true;
            isActive = false;
            index = 0;
        }
    }

    void UpdateDialogue(int sprite, string name, string body) {
        profile_icon.sprite = Conditions.conditions.icons[sprite];
        nameText.text = name;
        bodyText.text = body;
    }
    void UpdateDialogue(dialogueStruct d) {
        profile_icon.sprite = Conditions.conditions.icons[d.sprite];
        nameText.text = d.nameText;
        bodyText.text = d.bodyText;
    }
}
