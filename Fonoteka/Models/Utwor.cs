//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fonoteka.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Utwor
    {
        public int IdUtworu { get; set; }
        public int IdZespolu { get; set; }
        public string Tytul { get; set; }
        public System.TimeSpan CzasTrwania { get; set; }
    
        public virtual Utwor Zespol { get; set; }
    }
}
