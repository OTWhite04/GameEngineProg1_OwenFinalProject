using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo_SpawnPoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {

        // Draw a sphere at the spawn point
        Gizmos.color = Color.cyan;   // You can change the color here
        Gizmos.DrawWireSphere(transform.position, 0.25f); // Draw a sphere at the spawn point location with radius 0.5

    }
}
