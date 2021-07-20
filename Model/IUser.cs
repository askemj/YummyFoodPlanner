using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IUser
    {
        string UserName { get; set; }
        string Password { get; set; }
    }
}
