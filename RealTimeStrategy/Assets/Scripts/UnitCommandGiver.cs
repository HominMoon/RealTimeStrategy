using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitCommandGiver : MonoBehaviour
{
    [SerializeField] UnitSelectionHandler unitSelectionHandler;

    Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;
    }

    private void Update() {
        
    }
}
