//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewProject1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblLogin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Nullable<int> IsActive { get; set; }
        public Nullable<int> U_Type { get; set; }
        public Nullable<System.DateTime> c_date { get; set; }
        public Nullable<System.DateTime> u_date { get; set; }
        public Nullable<int> is_active { get; set; }
        public string image { get; set; }
    }
}
