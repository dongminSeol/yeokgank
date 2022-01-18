using System.Linq;

namespace yeokgank.Repository.Usermaster.Queries
{
    public class UserMasterQueries : IUserMasterQueries
    {
        private readonly yeokgankDbContext _yeokgankDbContext;
        public UserMasterQueries(yeokgankDbContext yeokgankDbContext)
        {
            _yeokgankDbContext = yeokgankDbContext;
        }
        public bool CheckUserExists(string username)
        {
            var data = (from userMaster in _yeokgankDbContext.UserMasters
                        where userMaster.UserName == username
                        select userMaster).Any();
            return data;
        }
        public bool CheckMailExists(string emailId)
        {
            var data = (from usermaster in _yeokgankDbContext.UserMasters
                        where usermaster.EmailId == emailId
                        select usermaster).Any();
            return data;
        }
    }
}
