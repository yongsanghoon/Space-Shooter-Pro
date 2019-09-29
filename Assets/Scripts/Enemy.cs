using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move down 4m/s
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // If bottom of screen: respawn at top with new random x position
        if (transform.position.y < -5f)
        {
            float x = Random.Range(-8f, 8f);
            transform.position = new Vector3(x, 7, 0);
        }
    }

    // Used to detect who collided with the laser (passthrough)
    private void OnTriggerEnter(Collider other)
    {
        // Log who collided with the enemy
        //Debug.Log("Hit: " + other.transform.name);

        // If other is player (using tags) --> dmg player first, then destroy enemy
        if (other.tag == "Player")
        {
            // Damage the player
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            // Destroy yourself (enemy)
            Destroy(this.gameObject);
        }
        else if (other.tag == "Laser")
        {
            // Destroy laser
            Destroy(other.gameObject);

            // Destroy yourself (enemy)
            Destroy(this.gameObject);
        }
    }
}
