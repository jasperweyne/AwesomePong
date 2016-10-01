using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public abstract class State
    {
        public abstract void Update();
        public abstract void Draw();
    }
}
