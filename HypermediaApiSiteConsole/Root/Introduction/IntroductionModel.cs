using System;
using System.Collections.Generic;
using HypermediaApiSiteConsole.Root.Learning;
using Tavis;

namespace HypermediaApiSiteConsole.Root.Introduction
{
    public class IntroductionModel
    {
        public string Definition { get; set; }
        public List<InfoNode> Usages { get; set; }


        public IntroductionModel() {
            Definition = "The most simplistic definition of Hypermedia is content with links.";

            Usages  = new List<InfoNode>();
            Usages.Add(new InfoNode()
            {
                Link = new Link() { Title = "Relations", Target = new Uri("https://github.com/RESTFest/2012-greenville/wiki/Hypermedia-Examples") },
                Description = "Links between related concepts"
            });
            Usages.Add(new InfoNode()
            {
                Link = new Link() { Title = "Static Resources", Target = new Uri("https://github.com/RESTFest/2012-greenville/wiki/Hypermedia-Examples") },
                Description = "Links to static resources to embed"
            });
            Usages.Add(new InfoNode()
            {
                Link = new Link() { Title = "Redirection", Target = new Uri("https://github.com/RESTFest/2012-greenville/wiki/Hypermedia-Examples") },
                Description = "Clients use dynamic bookmarks to refer to a resource to allow URIs to change. Discovery documents can provide lists of uris to populate bookmarks."
            });
            Usages.Add(new InfoNode()
            {
                Link = new Link() { Title = "Reference data", Target = new Uri("https://github.com/RESTFest/2012-greenville/wiki/Hypermedia-Examples") },
                Description = "Data sources for drop downs, combos, picklists."
            });

            Usages.Add(new InfoNode()
            {
                Link = new Link() { Title = "Reduction of payload size", Target = new Uri("https://github.com/RESTFest/2012-greenville/wiki/Hypermedia-Examples") },
                Description = "Progressive download of details."
            });


            Usages.Add(new InfoNode()
            {
                Link = new Link() { Title = "Re-distribution of effort", Target = new Uri("https://github.com/RESTFest/2012-greenville/wiki/Hypermedia-Examples") },
                Description = "Intelligent vertical partitioning of functionality across servers."
            });
            Usages.Add(new InfoNode()
            {
                Link = new Link() { Title = "Restriction of functionality", Target = new Uri("https://github.com/RESTFest/2012-greenville/wiki/Hypermedia-Examples") },
                Description = "Enabling and disabling features based on the presence of links."
            });

            Usages.Add(new InfoNode()
            {
                Link = new Link() { Title = "Reactive applications", Target = new Uri("https://github.com/RESTFest/2012-greenville/wiki/Hypermedia-Examples") },
                Description = "Links to control application flow."
            });
        }

    }
}
