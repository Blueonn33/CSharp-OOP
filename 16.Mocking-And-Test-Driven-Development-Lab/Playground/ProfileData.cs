using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class ProfileData
    {
        public List<Profile> All()
        {
            // Read database
            return new List<Profile>
            {
                new Profile {Username = "martin.marinov"}
            }
        }
    }
}
