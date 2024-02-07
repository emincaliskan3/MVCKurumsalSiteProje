using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCKurumsalSiteProje.Models
{
    public class HomePageViewModel
    {
        public List<Slide> Slides { get; set; }
        public List<Category> Categories { get; set; }
        public List<Post> Posts { get; set; }


    }
}