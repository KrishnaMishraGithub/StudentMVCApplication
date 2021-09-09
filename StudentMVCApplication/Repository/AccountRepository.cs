using StudentMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApplication.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly StudentContext _studentContext;
        
        public AccountRepository(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        public SignUpUser GetAllUser()
        {
            SignUpUser signUpUser = new SignUpUser();
            List<SignUpUser> signUpUsersList = new List<SignUpUser>();
            signUpUsersList = _studentContext.SignUpUsers.ToList();

            foreach (var user in signUpUsersList)
            {
                signUpUser.FirstName = user.FirstName;
                signUpUser.LastName = user.LastName;
                signUpUser.Email = user.Email;
                signUpUser.DateOfBirth = user.DateOfBirth;
                signUpUser.MobileNumber = user.MobileNumber;
                signUpUser.SignUpId = user.SignUpId;

            }

            return signUpUser;
        }
    }
}
