﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LEnglish.Models
{
    public class PictureViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        [DisplayName("Upload image file")]
        public string ImagePath { get; set; }

        public ICollection<WordViewModel> WordViewModels { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}