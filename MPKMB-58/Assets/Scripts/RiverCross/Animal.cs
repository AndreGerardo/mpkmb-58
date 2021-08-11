using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalKind{Sheep, Wolf};

public class Animal : MonoBehaviour
{
    private Transform startPos;
    public AnimalKind kind;

    void Start()
    {
        startPos.position = transform.position;
    }
}
