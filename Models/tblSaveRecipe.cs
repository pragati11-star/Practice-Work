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
    
    public partial class tblSaveRecipe
    {
        public int Id { get; set; }
        public Nullable<int> RecipeId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual TblReceipe TblReceipe { get; set; }
    }
}
