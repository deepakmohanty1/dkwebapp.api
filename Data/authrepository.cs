using System.Threading.Tasks;
using dkwebapp.api.models;
using Microsoft.EntityFrameworkCore;

namespace dkwebapp.api.Data
{
    public class authrepository : iauthrepository
    {
        private datacontext objcontext;
        public authrepository(datacontext ocontext)
        {
            objcontext=ocontext;
        }
        public async Task<usermaster> login(string username, string password)
        {
            var objuser=await objcontext.users.SingleOrDefaultAsync(x => x.username==username);
            if(objuser == null)
            {
               return null;
            }
            else
            {
               if (verifypasswordhassh( password,objuser.passwordhash,objuser.passwordsalt))
               {
                  return objuser;
               }
            }
            return null;
        }

         private bool verifypasswordhassh(string password, byte[] passwordhash, byte[] passwordsalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512(passwordsalt))
            {
                var computedhasash= hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                if(passwordhash.Length == computedhasash.Length)
                {
                    for (int i = 0; i < computedhasash.Length; i++)
                    {
                        if(passwordhash[i]!=computedhasash[i]) return false;
                    }
                    return true;
                }
            }
            return false;
        }
        public async Task<usermaster> register(usermaster objuser, string password)
        {
            byte[]  passwordsalt, passwordhash;
            createpasswordhash( password, out  passwordhash, out  passwordsalt);
           
           objuser.passwordhash=passwordhash;
           objuser.passwordsalt=passwordsalt;

           await objcontext.users.AddAsync(objuser);
           await objcontext.SaveChangesAsync();

           return objuser;
        }
        private void createpasswordhash(string password, out byte[] passwordhash, out byte[] passwordsalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordsalt= hmac.Key;
                passwordhash= hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public async Task<bool> userexists(string username)
        {
           if(await objcontext.users.AnyAsync( x => x.username ==username))
           {
              return true;
           }
           return false;
        }
    }
}