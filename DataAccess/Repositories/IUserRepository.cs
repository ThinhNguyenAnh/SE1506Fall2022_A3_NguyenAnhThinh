using BusinessObject;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IUserRepository
    {

        public User UserById(string id);

        public User Login(string emailOrUserName, string password);

        public bool Register(string email, string userName, string password);

        IEnumerable<User> GetUsers();

        bool InsertUser(AddUserRequest request);

        bool UpdateUser(string key,UpdateUserRequest request);

        bool DeleteUser(string ID);
    }
}
