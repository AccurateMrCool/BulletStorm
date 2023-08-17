using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletBehavior
{
    float bulletSpeed { get; set; }
    void Move();
}
