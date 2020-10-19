using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projector))]
public class TurnOffDarkness : MonoBehaviour
{
    private Projector projector;

    private void Start() {
        this.projector = GetComponent<Projector>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "FOVCollider"){
            projector.enabled = false;
        }
    }
}
