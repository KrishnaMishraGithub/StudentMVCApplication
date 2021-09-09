using StudentMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApplication.Repository
{
    public interface IAccountRepository
    {
        SignUpUser GetAllUser();
    }
}
