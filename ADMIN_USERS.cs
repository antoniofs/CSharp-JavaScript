//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoEcommerce.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ADMIN_USERS
    {
        public decimal ID { get; set; }
        public string NOME { get; set; }
        public string FUNCAO { get; set; }
        public string EMAIL { get; set; }
        public Nullable<short> STATUS { get; set; }
        public System.DateTime DATACRIACAO { get; set; }
        public Nullable<System.DateTime> DATAALTERACAO { get; set; }
        public string USER_LOGIN { get; set; }
        public string SENHA_LOGIN { get; set; }
    }
}
