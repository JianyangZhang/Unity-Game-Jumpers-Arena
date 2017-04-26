using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public interface IDamage
    {
        void Damage(int damage);

        int Hp { get; set; }
        int MaxHp { get; set; }
        bool IsIDamageWork { get; }
        bool IsShield { get; }
    }
}