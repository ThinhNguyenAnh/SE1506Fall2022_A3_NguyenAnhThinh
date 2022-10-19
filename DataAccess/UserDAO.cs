using BusinessObject;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDAO
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private static UserDAO instance = null;
        private static readonly object instanceLock = new object();
        private UserDAO() { }

        public UserDAO(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }

        public bool Register(string email, string userName, string password)
        {
            var user = new User
            {
                Email = email,
                UserName = userName,
            };


            var rs = _userManager.CreateAsync(user, password);
            if (rs.IsCompletedSuccessfully)
            {
                return true;
            }
            return false;
        }

        public User Login(string emailOrUserName, string password)
        {
            var rs = _signInManager.PasswordSignInAsync(emailOrUserName, password, false, true);
            if (rs.IsCompletedSuccessfully)
            {
                var user = _userManager.FindByEmailAsync(emailOrUserName).GetAwaiter().GetResult();
                return user;
            }
            return null;
        }

        public IEnumerable<User> GetUserList()
        {
            List<User> user;
            try
            {
                var FStoreDB = new eStoreDBContext();
                user = FStoreDB.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }


        public bool Create(AddUserRequest request)
        {

            User newUser = new()
            {
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber

            };

            var rs = _userManager.CreateAsync(newUser, request.Password);
            if (rs.IsCompletedSuccessfully)
            {
                return true;
            }

            return false;


        }

        public User GetByID(string ID)
        {
            var FStoreDB = new eStoreDBContext();

            var user = FStoreDB.Users.FindAsync(int.Parse(ID)).GetAwaiter().GetResult();
            if (user == null)
            {
                return null;
            }
            return user;

        }

        public bool Delete(string ID)
        {
            var user = GetByID(ID);
            var FStoreDB = new eStoreDBContext();

            if (user == null)
            {
                return false;
            }
            FStoreDB.Users.Remove(user);
            var rs = FStoreDB.SaveChanges();

            if (rs > 0)
            {
                return true;
            }

            return false;
        }




        public bool Update(string ID,UpdateUserRequest request)
        {
            var user = GetByID(ID);
            var FStoreDB = new eStoreDBContext();

            if (user == null)
            {
                return false;
            }
            user.PhoneNumber = request.PhoneNumber;
            FStoreDB.Users.Update(user);
            var rs = FStoreDB.SaveChanges();

            if (rs > 0)
            {
                return true;
            }

            return false;
        }
    }
}
