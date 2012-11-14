using System;
using Tavis;

namespace HypermediaApiContent.Model {
    public class InfoNode
    {
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public String Title { get; set; }
        public Link Link { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}