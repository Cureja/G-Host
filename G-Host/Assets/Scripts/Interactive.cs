using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactive : MonoBehaviour
{
    private DialogueController dialogueController;
    public SpriteRenderer sprite;
    public bool Possessed = false;
    public Vector3 InterPos;
    public PlayerController player;
    public List<dialogueStruct> ghostDialogue;
    public List<dialogueStruct> dialogue;
    public string scene;
    public bool isDoor = false;
    public bool isPossessable = true;
    public bool solved = false;

    // Start is called before the first frame update
    void Start()
    {
        dialogueController = GameObject.Find("Dialogue").GetComponent<DialogueController>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Possessed == true)
        {
            gameObject.transform.parent.gameObject.transform.position = player.PlayerPos;
        }
    }

    public void Interacted()
    {
        if(isDoor) {
            SceneManager.LoadScene(scene);
        } 
        else if (isPossessable && player.Possessioning != true) {
            player.Possession();
            sprite.color = Color.green;
            Possessed = true;
            player.possessed = gameObject.GetComponent<Interactive>();
            InterPos = transform.position;
            gameObject.transform.parent.gameObject.GetComponent<Collider>().enabled = false;
        } 
        else if(player.Possessioning && dialogue.Count > 0 && !player.InDialogue) {
            dialogueController.LoadDialogue(dialogue);
            player.InDialogue = true;
        } 
        else if(!player.Possessioning && dialogue.Count > 0 && !player.InDialogue) {
            dialogueController.LoadDialogue(ghostDialogue);
            player.InDialogue = true;
        }
        else if(player.Possessioning == true && dialogue.Count > 0 && !player.InDialogue) {
            dialogueController.LoadDialogue(dialogue);
            player.InDialogue = true;
        }
    }

    public void Unpossessed()
    {
        sprite.color = Color.white;
        Possessed = false;
        gameObject.transform.parent.gameObject.GetComponent<Collider>().enabled = true;
    }

}
