using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics.Contracts;

namespace GetBit_Project
{
    abstract class IGameObject
    {
        public abstract void Update();
        public abstract void Render(Graphics paper);
    }

    
}
