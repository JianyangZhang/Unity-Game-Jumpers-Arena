using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public interface IDamage
    {
        void Damage(int damage);

        int Hp { get; set; }
        bool IsIDamageWork { get; }
    }
}