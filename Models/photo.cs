﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;


namespace mvc_demo.Models
{ 

    public class Photo
    {
        //PhotoID. This is the primary key 
        [Key]
        public int PhotoID { get; set; }

        //Title. The title of the photo

        [Required]
        public string Title { get; set; }

        //PhotoFile. This is a picture file 
        [DisplayName("Picture")]
        [MaxLength]
        public byte[] PhotoFile { get; set; }

        //ImageMimeType, stores the MIME type for the PhotoFile 
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        //Description. 
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        //CreatedDate 
        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode
= true)]
        public DateTime CreatedDate { get; set; }

        //UserName. This is the name of the user who created the photo 
        public string UserName { get; set; }

        //All the comments on this photo, as a navigation property 
        public virtual ICollection<Comment> Comments { get; set; }
    }





}