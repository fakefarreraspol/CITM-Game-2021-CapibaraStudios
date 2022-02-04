using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth.OnTakeDamage(15);
        }
        if(other.tag != "Enemy")
        {
            Destroy(gameObject);

        }
    }


}
