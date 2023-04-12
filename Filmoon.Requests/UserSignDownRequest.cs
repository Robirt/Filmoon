using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmoon.Requests
{
    public class UserSignDownRequest
    {
        public UserSignDownRequest()
        {

        }

        public UserSignDownRequest(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
}
