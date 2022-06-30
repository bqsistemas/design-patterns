using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class NormalEnemy : Enemy
    {
        public override double TotalSpecialPower => 100;
        public override double SpecialPowerUses => 2;
    }
}
