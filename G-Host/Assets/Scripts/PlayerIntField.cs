using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntField : MonoBehaviour
{
    public List<Interactive> interactives = new List<Interactive>();
    public PlayerController player;
    private Interactive possessed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        interactives = new List<Interactive>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactive Npc"))
        {
            interactives.Add(other.gameObject.GetComponent<Interactive>());
        }
    }


    public void tryInteract()
    {
        foreach(Interactive i in interactives) {
            i.Interacted();
        }
        // if (interactives.Count!=0)
        // {
        //     interactives[0].Interacted();
        // }
    } 
    
    // public void tryUnpossess()
    // {
    //     if(interactives.Count!=0)
    //     {
    //         interactives[0].Unpossessed();
    //     }
    // }
}
