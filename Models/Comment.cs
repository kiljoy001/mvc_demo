﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace mvc_demo.Models
{
    public class Comment
    {
        //CommentID. This is the Primary Key 
        [Key]
        public int CommentID { get; set; }

        //PhotoID. This is the ID of the photo that this comment relates to 
        public int PhotoID { get; set; }

        //UserName. This is the name of the user who made this comment 
        [DisplayName("Author")]
        public string UserName { get; set; }

        //Subject. 
        [Required]
        [StringLength(250)]
        public string Subject { get; set; }

        //Body 
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        //Photo. This is the photo that this comment relates to as a navigation property
        public virtual Photo Photo { get; set; }
    }
}




