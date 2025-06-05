using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshTriggerBaker : MonoBehaviour
{
    public NavMeshSurface surface;
    public List<GameObject> objectsInTrigger = new List<GameObject>();

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (!objectsInTrigger.Contains(other.gameObject))
    //    {
    //        objectsInTrigger.Add(other.gameObject);
    //        UpdateNavMesh();
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (objectsInTrigger.Contains(other.gameObject))
    //    {
    //        objectsInTrigger.Remove(other.gameObject);
    //        UpdateNavMesh();
    //    }
    //}

    //private void UpdateNavMesh()
    //{
    //    // Temporarily enable relevant objects
    //    foreach (var go in GameObject.FindObjectsOfType<GameObject>())
    //        go.layer = 0; // Default layer so they don't get baked

    //    foreach (var go in objectsInTrigger)
    //        go.layer = LayerMask.NameToLayer("NavMesh"); // Custom layer

    //    surface.layerMask = LayerMask.GetMask("NavMesh");
    //    surface.BuildNavMesh();
    //}
}
