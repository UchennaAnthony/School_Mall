//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolMall.Model.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class PERSON
    {
        public PERSON()
        {
            this.SEARCHED_ITEM = new HashSet<SEARCHED_ITEM>();
            this.USER = new HashSet<USER>();
        }
    
        public long Person_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Other_Name { get; set; }
        public string Contact_Address { get; set; }
        public string Mobile_Number { get; set; }
        public int Sex_Id { get; set; }
    
        public virtual PERSON PERSON1 { get; set; }
        public virtual PERSON PERSON2 { get; set; }
        public virtual SEX SEX { get; set; }
        public virtual ICollection<SEARCHED_ITEM> SEARCHED_ITEM { get; set; }
        public virtual ICollection<USER> USER { get; set; }
    }
}