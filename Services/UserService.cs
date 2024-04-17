using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager2.Context;
using TaskManager2.Models;

namespace TaskManager2.Services
{
    public class UserService
    {
        private readonly ApplicationContext _dbContext;

        public UserService(ApplicationContext dbContext)
        { 

            _dbContext = dbContext;
        }

        public async Task<User> CreateUserAsync(string username, string password)
        {
            Guid userId = Guid.NewGuid();
            User newUser = new User
            {
                Id = userId,
                Username = username,
                Password = password
            };
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
            return newUser;
        }


        public async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                return false;
            }
            bool isPasswordValid = password == user.Password;
            return isPasswordValid;
        }        
    }
}