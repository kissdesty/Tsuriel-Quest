using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAAccion : ScriptableObject
{
    public abstract void Ejecutar(IAController controller);
}
