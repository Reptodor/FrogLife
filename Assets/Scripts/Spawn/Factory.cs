using System.Collections.Generic;
using UnityEngine;

public class Factory
{
    public List<PoolableGameObject> Create(PoolableGameObject spawningObject, int objectsCount)
    {
        List<PoolableGameObject> objects = new List<PoolableGameObject>();
        for (int i = 0; i < objectsCount; i++)
            objects.Add(Create(spawningObject));

        return objects;
    }

    private PoolableGameObject Create(PoolableGameObject spawningObject)
    {
        PoolableGameObject spawnedObject = Object.Instantiate(spawningObject);
        spawnedObject.Initialize();

        return spawnedObject;
    }
}
