using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSiteBanSach4.Models
{
    [MetadataTypeAttribute(typeof(SachMetadata))]
    public partial class Sach
    {
        internal sealed class SachMetadata
        {
            [Required(ErrorMessage = "{0} Can't be left blank")]
            [Display(Name = "Book ID")]
            public int MaSach { get; set; }
            [Required(ErrorMessage = "{0} Can't be left blank")]
            [Display(Name = "Book Name")]
            public string TenSach { get; set; }
            [Required(ErrorMessage = "{0} Can't be left blank")]
            [Display(Name = "Price")]
            public Nullable<decimal> GiaBan { get; set; }
            [Required(ErrorMessage = "{0} Can't be left blank")]
            [Display(Name = "Description")]
            public string MoTa { get; set; }
            [Required(ErrorMessage = "{0} Can't be left blank")]
            [Display(Name = "Figure")]
            public string AnhBia { get; set; }
            [Required(ErrorMessage = "{0} Can't be left blank")]
            [Display(Name = "Update day")]
            public Nullable<System.DateTime> NgayCapNhat { get; set; }
            [Required(ErrorMessage = "{0} Can't be left blank")]
            [Display(Name = "Quantity")]
            public Nullable<int> SoLuongTon { get; set; }
            [Required(ErrorMessage = "{0} Can't be left blank")]
            [Display(Name = "Publisher ID")]
            public Nullable<int> MaNXB { get; set; }
           
            [Display(Name = "Category ID")]
            public Nullable<int> MaChuDe { get; set; }
           
            [Display(Name = "Status")]
            public Nullable<int> Moi { get; set; }
        }
    }
}