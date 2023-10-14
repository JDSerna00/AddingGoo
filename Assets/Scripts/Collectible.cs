using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int powerQuantity;
    private void OnTriggerEnter2D(Collider2D other)
    {       

        if (other.CompareTag("Goo"))
        {
            Collect(other.GetComponent<Player>());
            Destroy(gameObject);
            Debug.Log("Object that entered the trigger : " + other);
        }
    }
    public void Collect(Player player)
    {
        player.PowerUp(powerQuantity);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
