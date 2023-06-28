using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemigoBarraVida : MonoBehaviour
{
    [SerializeField] private Image barraVida;
    private float saludActual;
    private float saludMax;

    // Update is called once per frame
    void Update()
    {
        barraVida.fillAmount =Mathf.Lerp(barraVida.fillAmount, saludActual /saludMax, 10f* Time.deltaTime);
    }

    public void ModificarSalud(float pSaludActual, float pSaludMax){
        saludActual= pSaludActual;
        saludMax= pSaludMax;

    }
}
