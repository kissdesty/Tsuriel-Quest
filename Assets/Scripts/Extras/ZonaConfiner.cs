using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZonaConfiner : MonoBehaviour

{
[SerializeField] private CinemachineVirtualCamera camara;


private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Player")){
        camara.gameObject.SetActive(true);
    }
    
}

private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
        camara.gameObject.SetActive(false);
    }
}



}
