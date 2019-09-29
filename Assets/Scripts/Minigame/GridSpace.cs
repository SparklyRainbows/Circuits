using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour
{
    public Cable cable;

    private float rotationSpeed = 10f;
    private bool isRotating;

    private void OnMouseUp() {
        if (cable.cableType == CableType.GENERATOR || cable.cableType == CableType.TARGET || cable.cableType == CableType.EMPTY)
            return;

        if (isRotating)
            return;

        if (Grid.instance.levelComplete)
            return;

        //transform.Rotate(Vector3.forward * -90);
        cable.RotateConnection();

        StartCoroutine(Rotate(transform.eulerAngles + Vector3.forward * -90));

        Grid.instance.UpdateConnections();
    }

    private IEnumerator Rotate(Vector3 target) {
        Vector3 startRotation = transform.eulerAngles;
        float rotatedAmount = 0;

        isRotating = true;

        while (rotatedAmount < 1) {
            rotatedAmount += rotationSpeed / 90f;
            transform.eulerAngles = Vector3.Lerp(startRotation, target, rotatedAmount);
            yield return null;
        }

        isRotating = false;
    }
}

public class Cable {
    private List<int> connections;
    public CableType cableType;
    private float rotation;
    
    //Cable is set to default position with 0 rotation
    public Cable(CableType cable) {
        cableType = cable;
        rotation = 0;

        SetConnections();
    }

    public Cable(CableType cable, int r) {
        cableType = cable;
        rotation = r * 90;

        SetConnections();
        Rotate(r);
    }

    #region connection_functions
    private void SetConnections() {
        connections = new List<int>();

        switch(cableType) {
            case CableType.EMPTY:
                return;
            case CableType.GENERATOR:
                connections.Add(0);
                connections.Add(1);
                connections.Add(2);
                connections.Add(3);
                return;
            case CableType.BOMB:
                connections.Add(0);
                connections.Add(1);
                connections.Add(2);
                connections.Add(3);
                return;
            case CableType.TARGET:
                connections.Add(0);
                connections.Add(1);
                connections.Add(2);
                connections.Add(3);
                return;
            case CableType.STRAIGHT:
                connections.Add(0);
                connections.Add(2);
                break;
            case CableType.CORNER:
                connections.Add(0);
                connections.Add(1);
                break;
            case CableType.T:
                connections.Add(0);
                connections.Add(1);
                connections.Add(2);
                break;
            case CableType.CROSS:
                connections.Add(0);
                connections.Add(1);
                connections.Add(2);
                connections.Add(3);
                return;
            default:
                Debug.LogWarning($"CableType not found: {cableType}");
                return;
        }
    }

    public bool HasConnection(int c) {
        return connections.Contains(c);
    }

    public List<int> GetConnections() {
        return connections;
    }
    #endregion

    #region rotation_functions
    private void Rotate(int rotations) {
        for (int i = 0; i < rotations; i++) {
            RotateConnection();
        }
    }

    private void SetRotation(float r) {
        rotation = r;

        if (cableType == CableType.EMPTY || cableType == CableType.CROSS)
            return;

        //Rotate depending on your rotation
        int rotations = 0;
        if (rotation == 90)
            rotations = 1;
        else if (rotation == 180)
            rotations = 2;
        else if (rotation == 270)
            rotations = 3;

        Rotate(rotations);
    }

    //Rotates connection by 90 degrees
    public void RotateConnection() {
        for (int i = 0; i < connections.Count; i++) {
            int newConnection = connections[i] + 1;
            if (newConnection > 3) {
                newConnection -= 4;
            }

            connections[i] = newConnection;
        }

        //PrintConnections();
    }

    public float GetRotation() {
        return rotation;
    }

    private void PrintConnections() {
        string str = cableType + " ";
        foreach(int c in connections) {
            str += c + " ";
        }

        Debug.Log(str);
    }
    #endregion

}

public enum CableType {
    STRAIGHT,
    CROSS,
    T,
    CORNER,
    EMPTY,
    GENERATOR,
    TARGET,
    BOMB
}