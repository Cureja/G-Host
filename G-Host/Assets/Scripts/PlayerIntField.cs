using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntField : MonoBehaviour
{
    public List<Interactive> interactives = new List<Interactive>();
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
        if (interactives.Count!=0)
        {
            interactives[0].Interacted(); 
        }
    } 
}
