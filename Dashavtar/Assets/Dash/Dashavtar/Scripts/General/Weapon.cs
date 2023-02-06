using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    /*Weapon script i.e one that requires projectile*/

    #region Variables

    [Header("Weapon variables")]
    public GameObject projectile;
    public GameObject Shooter;
    public Transform shotPoint;
    public float launchForce;
    GameObject newProjectile;

    #endregion

    #region Functions

    public void Shoot()
    {
        newProjectile = Instantiate(projectile, shotPoint.position, projectile.transform.rotation);

        if (Shooter.transform.rotation.y == 0)
            newProjectile.transform.rotation = Quaternion.Euler(0, 0, -90);

        if (Shooter.transform.rotation.y == -1)
            newProjectile.transform.rotation = Quaternion.Euler(0, 0, 90);

        newProjectile.GetComponent<Rigidbody2D>().AddForce(transform.right * launchForce, ForceMode2D.Impulse);

    }
}


#endregion

