using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public SpriteRenderer sprite;
    public bool Possessed = false;
    public Vector3 InterPos;
    public PlayerController player;




    // Start is called before the first frame update
    void Start()
    {
        
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
        sprite.color = Color.green;
        Possessed = true;
        InterPos = transform.position;
        gameObject.transform.parent.gameObject.GetComponent<Collider>().enabled = false;
    }

    public void Unpossessed()
    {
        sprite.color = Color.white;
        Possessed = false;
        gameObject.transform.parent.gameObject.GetComponent<Collider>().enabled = true;
    }

}
