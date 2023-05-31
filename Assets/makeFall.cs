using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
//using static TreeEditor.TreeEditorHelper;

public class makeFall : MonoBehaviour
{
    private float  x,y;
    // Start is called before the first frame update

    private void Start()
    {
        this.x = transform.position.x;
        this.y = transform.position.y;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.name == "Player")
        {
            Invoke("ActivateFall", 0.2f);
            
            
        }
    }

    private void ActivateFall()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().freezeRotation = true;
        Invoke("Hide", 1f);
    }
    private void Hide()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        
        Invoke("Show", 5f);
    }
    private void Show()
    {
        transform.position = new Vector2(x,y);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

}
