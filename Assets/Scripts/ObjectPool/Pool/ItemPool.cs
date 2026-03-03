using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoSingleton<ItemPool> 
{
    protected float m_ReleaseTime;

    protected long m_LastReleaseTime = 0;

    [SerializeField] private Transform ItemRoot;

    private List<PoolObject> _items;


    public void Start()
    {
        m_LastReleaseTime = System.DateTime.Now.Ticks;
    }
    private void Update()
    {
        if (System.DateTime.Now.Ticks - m_ReleaseTime >= m_ReleaseTime * 10000000)
        {
            m_LastReleaseTime = System.DateTime.Now.Ticks;
            Release();
        }
    }
    public void Init(float time)
    {
        m_ReleaseTime = time;
        _items = new List<PoolObject>();
    }

    public void UnSpawn(GameObject item,string name)
    {
        PoolObject @object = new PoolObject(item, name);
        _items.Add(@object);

        item.SetActive(false);
        item.transform.parent = ItemRoot;
    }
    
    public Object Spawn(string name)
    {
        Object pobj = null;
        foreach(PoolObject obj in _items)
        {
            if (obj.Name == name)
            {
                _items.Remove(obj);
                pobj = obj.Object;
                break;
            }
        }

        GameObject go = pobj as GameObject;
        if (go != null)
        {
            go.SetActive(true);
            return go;
        }
        return null;
    }

    public void Release()
    {
        foreach (PoolObject item in _items)
        {
            if (System.DateTime.Now.Ticks - item.LastUsedTime.Ticks >= m_ReleaseTime * 10000000)
            {
                Debug.Log("GameObjectPool release time:" + System.DateTime.Now);
                Destroy(item.Object);
                _items.Remove(item);
                Release();
                return;
            }
        }
    }
    

}
