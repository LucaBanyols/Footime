using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class JerseyDatabase : ScriptableObject
{
    public Jersey[] jersey;

    public int JerseyCount
    {
        get 
        {
            return jersey.Length;
        }
    }

    public Jersey GetJersey(int index)
    {
        return jersey[index];
    }
}
