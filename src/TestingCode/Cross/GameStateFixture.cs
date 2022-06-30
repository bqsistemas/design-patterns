using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCode.Cross
{
    public class GameStateFixture : IDisposable
    {
        public GameState State { get; private set; }

        public GameStateFixture()
        {
            State = new GameState();
        }

        public void Dispose()
        {
            
        }
    }
}
