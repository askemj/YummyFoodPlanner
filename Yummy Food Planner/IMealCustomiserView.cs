using System;
using System.Collections.Generic;
using System.Text;
using Model; 

namespace View
{
    public interface IMealCustomiserView
    {
        void LoadRecipe(IRecipe recipe);
    }
}
