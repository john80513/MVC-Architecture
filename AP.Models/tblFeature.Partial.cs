namespace ESunBank.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(tblFeatureMetaData))]
    public partial class tblFeature
    {
    }
    
    public partial class tblFeatureMetaData
    {
        [Required]
        public int SN { get; set; }
        public Nullable<int> FeatureId { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string MemberSN { get; set; }
        public Nullable<int> PhotoId { get; set; }
        [Required]
        public byte[] FeatureData { get; set; }
        [Required]
        public double QualityScore { get; set; }
    }
}
