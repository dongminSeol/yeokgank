using yeokgank.Entities.UserMaster;

namespace yeokgank.Repository.Usermaster.Command
{
    public interface IUserMasterCommand
    {
        void Add(UserMaster usermaster);
        void Update(UserMaster usermaster);
    }
}
