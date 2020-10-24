using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetApp.Core.Entities.Base
{
    //generic Id
    //entity will remain common for all
    //passing id which will remain same
    //why do we do interface?
    //ID AS GENERIC  
   public  interface IEntityBase<TID>
    {
        TID ID { get;}
    }
}
