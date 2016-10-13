using System;
using System.ComponentModel.DataAnnotations;

namespace TeduShop.Model.Abstract
{
    internal interface Auditable
    {
        [MaxLength(256)]
        string MetaKeyword { get; set; }

        [MaxLength(256)]
        string MetaDescription { get; set; }

        DateTime? CreateDate { get; set; }

        [MaxLength(256)]
        string CreatBy { get; set; }

        DateTime? UpdateDate { get; set; }

        [MaxLength(256)]
         string UpdateBy { get; set; }

         bool Status { get; set; }
    }
}