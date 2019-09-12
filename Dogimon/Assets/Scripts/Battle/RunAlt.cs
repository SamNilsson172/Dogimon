using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAlt : MonoBehaviour
{
    public Fight fight;

    public void Run()
    {
        fight.publicState = 4;
    }
}
