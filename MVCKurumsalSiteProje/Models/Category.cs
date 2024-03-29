﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCKurumsalSiteProje.Models
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı"), StringLength(150), Required]
        public string Name { get; set; }
        [Display(Name = "Açıklama"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Resim"), StringLength(150)]
        public string Image { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Anasayfada Göster")]
        public bool IsHome { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)] // ScaffoldColumn(false) özelliği oluşturulacak view ekranlarında bu alanı oluşturma demektir.
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public virtual List<Post> Posts { get; set; }
    }
}