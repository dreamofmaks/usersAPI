using System;
using System.Collections.Generic;
using System.Text;
using Users.Data.Model;

namespace Users.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Person AddUser(Person person);
    }
}
