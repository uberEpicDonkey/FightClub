//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FightClub.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class avatar
    {
        public avatar()
        {
            this.user = new HashSet<user>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<user> user { get; set; }
    }
}
