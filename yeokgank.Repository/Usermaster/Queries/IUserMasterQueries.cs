using System;
using System.Collections.Generic;
using System.Text;

namespace yeokgank.Repository.Usermaster.Queries
{
    public interface IUserMasterQueries
    {
        bool CheckUserExists(string username);
        bool CheckMailExists(string username);

    }
}
