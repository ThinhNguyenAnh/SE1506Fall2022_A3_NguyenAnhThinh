using BusinessObject;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public bool DeleteUser(string ID) => UserDAO.Instance.Delete(ID);
       

        public IEnumerable<User> GetUsers() => UserDAO.Instance.GetUserList();


        public bool InsertUser(AddUserRequest request) => UserDAO.Instance.Create(request);


        public User Login(string emailOrUserName, string password) => UserDAO.Instance.Login(emailOrUserName,password);


        public bool Register(string email, string userName, string password) => UserDAO.Instance.Register(email,userName,password);


        public bool UpdateUser(string key,UpdateUserRequest request) => UserDAO.Instance.Update(key,request);


        public User UserById(string id) => UserDAO.Instance.GetByID(id);

    }
}
