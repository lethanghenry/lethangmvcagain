using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Basic_level2_agan.Models
{
    public class Blog
    {
        public int? id { get; set; }
        
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string tin { get; set; }
        
         [StringLength(60, MinimumLength = 2)]
         [Required]     
        public string loai { get; set; }
      
         [StringLength(60, MinimumLength = 2)]
         [Required]
        public string trangThai { get; set; }  
    
         [StringLength(60, MinimumLength = 2)]
         [Required]
        public string viTri { get; set; }

         [StringLength(60, MinimumLength = 2)]
         [Required]
         public string motangan { get; set; }

         [StringLength(60, MinimumLength = 2)]
         [Required]
         public string chitiet { get; set; }

        [Required(ErrorMessage="Enter the issue date")]
        [DataType(DataType.Date)]
        public DateTime ngayPublic { get; set; }
    

        
    }
    public class BlogDBContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
    }
    public class SelectType
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }

}