using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD.Common.HttpClients
{
    public class UserHttpClient 
    {
        public HttpClient Client { get; }

        public UserHttpClient(HttpClient httpClient)
        {
            Client = httpClient;
        }

        public async Task CreateUser(CreateUserModel model)
        {
            try
            {
                if(model is null) throw new ArgumentExcpetion("CreateUserModel is null");
            }

            catch 
            {

            }
        }
    }
}
