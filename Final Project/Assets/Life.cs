using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] public int life;

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life--;
        }
    }

    private void Update()
    {
        if (life <=0) 
        {
            Destroy(gameObject);
        }
    }
}
