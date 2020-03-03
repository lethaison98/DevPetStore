using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Common
{
    [Serializable]
    public class UserLogin
    {        
        public int UserID { get; set; }
        public int UserName { get; set; }
    }
}