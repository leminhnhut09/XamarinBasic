using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BlogApp.Services
{
    public interface IEnvironment
    {
        void SetStatusBarColor(Color color, bool darkStatusBarTint);
    }
}
