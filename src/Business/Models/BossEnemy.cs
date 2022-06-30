using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class BossEnemy : Enemy
    {
        public override double TotalSpecialPower => 1000;
        public override double SpecialPowerUses => 6;
    }
}
