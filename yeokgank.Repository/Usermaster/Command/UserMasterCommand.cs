using yeokgank.Entities.UserMaster;
using Microsoft.EntityFrameworkCore;
namespace yeokgank.Repository.Usermaster.Command
{
    public class UserMasterCommand : IUserMasterCommand
    {

        private readonly yeokgankDbContext _dbContext;


        public UserMasterCommand(yeokgankDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(UserMaster usermaster)
        {
            _dbContext.UserMasters.Add(usermaster);
        }

        public void Update(UserMaster usermaster)
        {
            //_dbContext.UserMasters.Update(usermaster);
            _dbContext.Entry(usermaster).State = EntityState.Modified;
        }
    }
}
