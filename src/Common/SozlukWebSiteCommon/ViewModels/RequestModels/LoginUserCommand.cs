using MediatR;
using SozlukWebSiteCommon.ViewModels.QueriesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSiteCommon.ViewModels.RequestModels
{
    public class LoginUserCommand:IRequest<LoginUserViewModel>
    {
        public LoginUserCommand(string eMailAddress, string password)
        {
            EMailAddress = eMailAddress;
            Password = password;
        }

        public string EMailAddress { get;  set; }
        public string Password { get;  set; }
        public LoginUserCommand()
        {
            
        }
    }
}
