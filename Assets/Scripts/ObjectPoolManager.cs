using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPoolManager : MonoBehaviour
{
    // Code adapted from Unity Object Pooling Made Easy: Learn to Manage Spawns Like a Pro | Unity Tutorial
    // https://youtu.be/9O7uqbEe-xc ,since it is my first time using an object pool.

    public static List<PooledObjectInfo> objectPools = new List<PooledObjectInfo>();

    // Method spawns an object either by re-activating an object in the pool or instantiating a new object.
    public static GameObject InstantiateFromPool(GameObject objectToSpawn, Vector3 spawnPos, Quaternion spawnRot)
    {
        // Find whether there already is a pool for this object type.
        PooledObjectInfo pool = objectPools.Find(p => p.lookupString == objectToSpawn.name);
        if (pool == null)
        {
            pool = new PooledObjectInfo() { lookupString = objectToSpawn.name };
            objectPools.Add(pool);
        }

        GameObject spawnableObj = pool.inactiveObjects.FirstOrDefault();

        // Find whether the object is already in the pool or whether it needs to be instantiated.
        if (spawnableObj == null)
        {
            spawnableObj = Instantiate(objectToSpawn, spawnPos, spawnRot);
        }
        else
        {
            spawnableObj.transform.position = spawnPos;
            spawnableObj.transform.rotation = spawnRot;
            pool.inactiveObjects.Remove(spawnableObj);
            spawnableObj.SetActive(true);
        }

        return spawnableObj;
    }

    public static void ReturnObjectToPool(GameObject obj)
    {
        string shortName = obj.name.Substring(0, obj.name.Length - 7); // Without (Clone)
        PooledObjectInfo pool = objectPools.Find(p => p.lookupString == shortName);
        
        if (pool == null)
        {
            Debug.LogWarning("Trying to release an object that is not pooled" + obj.name);
        }

        else
        {
            obj.SetActive(false);
            pool.inactiveObjects.Add(obj);
        }
    }
}

public class PooledObjectInfo
{
    public string lookupString;
    public List<GameObject> inactiveObjects = new List<GameObject>();
}
