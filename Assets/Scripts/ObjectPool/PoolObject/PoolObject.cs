using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject
{
    public Object Object;

    public string Name;

    public System.DateTime LastUsedTime;

    public PoolObject(Object obj,string name)
    {
        Object = obj;
        Name = name;
        LastUsedTime = System.DateTime.Now;
    }

}
