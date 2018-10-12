using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[DisallowMultipleComponent]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {



    TextMesh textMesh;
    Vector3 gridPos;
    Waypoint waypoint;

    void Awake()
    {

        GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }
     
    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        gridPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(gridPos.x, 0f, gridPos.z);
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = gridPos.x / gridSize + "," + gridPos.z / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
