using System;
using System.Collections.Generic;
using System.Text;
using yeokgank.Repository.Usermaster.Command;

namespace yeokgank.Repository
{
    public interface IUnitOfWorkEntityFramework
    {
        IUserMasterCommand UserMasterCommand { get;}
        bool Commit();
        void Dispose();

    }
}
