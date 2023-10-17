using DAL.Entities;
using Football.Models.AuthVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> LoginAsync(LoginUser loginuser);
        Task<AuthModel> UpdateAsync(UpdateVM userUpdate, ApplicationUser user);
    }
}
