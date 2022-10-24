using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLog : MonoBehaviour
{
    public void Log()
    {
        Debug.Log("eqweqweq");
    }

    public void LogValue(int value)
    {

        Debug.Log("Hoho hah" + value.ToString());
    }
    


}
