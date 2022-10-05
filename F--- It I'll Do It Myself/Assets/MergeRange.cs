using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeRange : MonoBehaviour
{
    [SerializeField] Me me;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Myself"))
        {
            me.onRange();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Myself"))
        {
            me.outOfRange();
        }
    }
}
