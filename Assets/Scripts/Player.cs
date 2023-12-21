using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isMoving;

    public PlayerMove move;
    public PlayerRotation rotation;

    public List<Skill> skillList;
}
