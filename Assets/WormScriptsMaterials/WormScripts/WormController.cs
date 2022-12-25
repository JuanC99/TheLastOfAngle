using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{

    public float health = 100;
    [SerializeField] private WormAnimationController animationController;
    [SerializeField] private WormWeaponsController weaponsController;
    [SerializeField] private Transform player;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        LookAtPlayer();
    }

    public void ActivateWorm()
    {
        animationController.ActivateWorm();
        weaponsController.ActivateWeapons();
    }


    private void LookAtPlayer()
    {
        transform.parent.LookAt(player, Vector3.up);
        transform.parent.rotation *= Quaternion.Euler(0, 82.5f, 0);
    }

    // Comprueba la vida del gusano, si es < = a 0 muere.
    private void CheckHealth()
    {
        if (health <= 0f)
        {
            animationController.AnimationDead();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        TakeDamage(other);
    }

    // Si es dañado por projectil de jugador se daña
    private void TakeDamage(Collision other)
    {
        PlayerProjectile playerProjectile = other.gameObject.GetComponent<PlayerProjectile>();
        print(other.transform.name);
        if (playerProjectile)
        {
            health = health - playerProjectile.damage;
        }
    }


}
