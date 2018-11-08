using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[DisallowMultipleComponent]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {


    TextMesh textMesh; 
    Waypoint waypoint;

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }
     
    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3
            (
                (waypoint.GetGridPos().x * gridSize),
            transform.position.y,
                (waypoint.GetGridPos().y * gridSize)
            );
    }

    private void UpdateLabel()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        textMesh.text = labelText;
        gameObject.name = labelText; 
    }
}
