using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillChecker : MonoBehaviour
{
    [SerializeField] private Transform[] pivot;
    [SerializeField] private LayerMask layerMask;
    public float viewRadius;
    public bool check = false;
    public bool RayChecker()
    {
        RaycastHit2D hit2D;

        for(int i = 0; i < pivot.Length; i++)
        {
            hit2D = Physics2D.CircleCast(pivot[i].position, viewRadius, Vector3.forward, Mathf.Infinity, layerMask);

            if (!hit2D)
            {
                return false;
            }
        }
        return true;
    }
}
