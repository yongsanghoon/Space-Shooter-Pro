using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootLaser();

    }

    void ShootLaser()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Veritcal");

        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        // 8
        if (transform.position.y >= 8)
        {
            Destroy(this.gameObject);
        }
    }
}
