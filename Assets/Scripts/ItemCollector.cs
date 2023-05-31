using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int strawBerryCount = 0;
    [SerializeField] private Text strawberryText;

    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            strawBerryCount++;
            strawberryText.text = "" + strawBerryCount;
        }
    }

    public int GetStrawCount()
    {
        return strawBerryCount;
    }
}
