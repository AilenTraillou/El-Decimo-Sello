using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class InspectorFloor : MonoBehaviour
{
    public float xGridScale = 1;
    public float yGridScale = 1;
    public float zGridScale = 1;

    void Update()
    {
        if (Application.isEditor) 
        {
            Transform[] childrens = GetComponentsInChildren<Transform>(); // Tomamos todos sus hijos
            for (int i = childrens.Length - 1; i >= 0; i--) // Recorremos la lista de hijos
            {
                Vector3 currentPosition = childrens[i].position; // Almacenamos su posicion
                float xDifference = currentPosition.x % xGridScale; // Calculamos la diferencia en x
                float yDifference = currentPosition.y % yGridScale; // Calculamos la diferencia en y
                float zDifference = currentPosition.z % zGridScale; // Calculamos la diferencia en z
                childrens[i].transform.position = new Vector3(
                    currentPosition.x - xDifference,
                    currentPosition.y - yDifference,
                    currentPosition.z - zDifference); // Reposicionamos al objeto
            }
        }
    }

}
