using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class EnemyCreationException : Exception
    {
        public EnemyCreationException(string message, string enemyName) : base(message)
        {
            RequestedEnemyName = enemyName;
        }

        public string RequestedEnemyName { get; private set; }
    }
}
