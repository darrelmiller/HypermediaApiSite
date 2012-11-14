using System;
using System.Collections.Generic;
using System.Linq;
using HypermediaApiSiteConsole.Model;
using HypermediaApiSiteConsole.Root.Learning;
using Tavis;

namespace HypermediaApiSiteConsole.Root.Introduction
{
    public class IntroductionModel
    {
        public string Definition { get; set; }
        public List<InfoNode> Usages { get; set; }
        public List<InfoNode> Articles { get; set; }

        public IntroductionModel(InfoRepository infoRepository) {


            Definition = "The most simplistic definition of Hypermedia is content with links.";

            Articles = (from i in infoRepository.GetNodes()
                      where i.Category == "Introduction" && i.SubCategory == "Article"
                      select i).ToList();

            Usages = (from i in infoRepository.GetNodes()
                      where i.Category == "Introduction" && i.SubCategory == "Usage"
                      select i).ToList();

        }

    }
}
