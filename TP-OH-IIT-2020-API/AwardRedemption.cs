//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP_OH_IIT_2020_API
{
    using System;
    using System.Collections.Generic;
    
    public partial class AwardRedemption
    {
        public int redemptionID { get; set; }
        public int useridFK { get; set; }
        public int awardIdFK { get; set; }
    
        public virtual AwardsTable AwardsTable { get; set; }
        public virtual User User { get; set; }
    }
}
