using System;
using System.Collections.Generic;
using Tavis;

namespace HypermediaApiContent.Model {
    public class InfoRepository {

        private List<InfoNode> _Nodes = new List<InfoNode>();

        public InfoRepository() {
            _Nodes.Add(new InfoNode() {
                                          Category = "Learning",
                                          SubCategory = "Videos",
                                          Link = new Link() {
                                                                Target = new Uri("http://oredev.org/2010/sessions/hypermedia-apis"),
                                                                Title = "Hypermedia APIs - Jon Moore"
                                                            },
                                          Description = ""
                                      });
            _Nodes.Add(new InfoNode() {
                                          Category = "Learning",
                                          SubCategory = "Videos",
                                          Link = new Link() {
                                                                Target = new Uri("http://www.infoq.com/presentations/Hypermedia-Web-Integration"),
                                                                Title =
                                                                    "The Role of Hypermedia and the Future of Web Integration - Guilherme Silveira"
                                                            },
                                          Description = ""
                                      });
            _Nodes.Add(new InfoNode() {
                                          Category = "Learning",
                                          SubCategory = "Videos",
                                          Link = new Link() {
                                                                Target =
                                                                    new Uri(
                                                                    "http://oredev.org/2010/sessions/hypermedia-apis"),
                                                                Title = "Hypermedia APIs - Jon Moore"
                                                            },
                                          Description = ""
                                      });

            _Nodes.Add(new InfoNode()
            {
                Category = "Learning",
                SubCategory = "Community",

                Link = new Link()
                {
                    Target =
                        new Uri(
                        "https://groups.google.com/forum/?fromgroups#!forum/hypermedia-web"),
                    Title = "Hypermedia Web - Google Groups"
                },
                Description =
                    "Mike Amundsen's list covering all things hypermedia related."
            });
            _Nodes.Add(new InfoNode()
            {
                Category = "Learning",
                SubCategory = "Community",

                Link = new Link()
                {
                    Target =
                        new Uri(
                        "https://groups.google.com/forum/?fromgroups#!forum/api-craft"),
                    Title = "Api-Craft - Google Groups"
                },
                Description =
                    "Mailing list managed by Apigee on subjects related to building and designing Web APIs."
            });

            _Nodes.Add(new InfoNode()
            {
                Category = "Learning",
                SubCategory = "Community",

                Link = new Link()
                {
                    Target =
                        new Uri(
                        "http://tech.groups.yahoo.com/group/rest-discuss/"),
                    Title = "REST Discuss - Yahoo Groups"
                },
                Description =
                    "The original home of the REST community.  Not exactly friendly for newcomers but the place to go when you want to hear an authoritative answer"
            });

            _Nodes.Add(new InfoNode()
            {
                Category = "Learning",
                SubCategory = "Community",
                Link = new Link()
                {
                    Target = new Uri("irc://freenode.net#rest"),
                    Title = "REST IRC Channel"
                },
                Description =
                    "Informal and generally friendly, this is great place to bounce an idea of some knowlegable people."
            });


            _Nodes.Add(new InfoNode()
            {
                Category = "Learning",
                SubCategory = "Examples",
                Link = new Link()
                {
                    Target = new Uri("http://code.google.com/p/huddle-apis/"),
                    Title = "Huddle Documentation"
                },
                Description =
                    "Huddle is a commercial document management application that has a hypermedia focused API"
            });
        

            _Nodes.Add(new InfoNode()
            {
                Category = "Learning",
                SubCategory = "Examples",
                Link = new Link()
                {
                    Target = new Uri("https://kenai.com/projects/suncloudapis/pages/Home"),
                    Title = "Sun Cloud Documentation"
                },
                Description =
                    "Sun Cloud is a REST based API for managing could based infrastructure"
            });
            
            
            _Nodes.Add(new InfoNode()
            {
                Category = "Introduction",
                SubCategory = "Usage",

                Link = new Link() { Title = "Relations", Target = new Uri("https://github.com/RESTFest/2012-greenville/wiki/Hypermedia-Examples") },
                Description = "Links between related concepts"
            });
            _Nodes.Add(new InfoNode()
            {
                Category = "Introduction",
                SubCategory = "Usage",

                Link = new Link() { Title = "Static Resources", Target = new Uri("https://github.com/RESTFest/2012-greenville/wiki/Hypermedia-Examples") },
                Description = "Links to static resources to embed"
            });
            _Nodes.Add(new InfoNode()
            {
                Category = "Introduction",
                SubCategory = "Usage",

                Link = new Link() { Title = "Redirection", Target = new Uri("https://github.com/RESTFest/2012-greenville/wiki/Hypermedia-Examples") },
                Description = "Clients use dynamic bookmarks to refer to a resource to allow URIs to change. Discovery documents can provide lists of uris to populate bookmarks."
            });
            _Nodes.Add(new InfoNode()
            {
                Category = "Introduction",
                SubCategory = "Usage",

                Link = new Link() { Title = "Reference data", Target = new Uri("https://github.com/RESTFest/2012-greenville/wiki/Hypermedia-Examples") },
                Description = "Data sources for drop downs, combos, picklists."
            });

            _Nodes.Add(new InfoNode()
            {
                Category = "Introduction",
                SubCategory = "Usage",

                Link = new Link() { Title = "Reduction of payload size", Target = new Uri("https://github.com/RESTFest/2012-greenville/wiki/Hypermedia-Examples") },
                Description = "Progressive download of details."
            });


            _Nodes.Add(new InfoNode()

            {
                Category = "Introduction",
                SubCategory = "Article",
                Author = "Mike Amundsen",
                Link = new Link() { Title = "Hypermedia H-Factors", Target = new Uri("http://www.amundsen.com/hypermedia/hfactor/") },
                Description = "Breakdown of the characteristics of hypermedia controls."
            });

            _Nodes.Add(new InfoNode()

            {
                Category = "Introduction",
                SubCategory = "Article",
                Author = "Mike Amundsen",
                Link = new Link() { Title = "Hypermedia Media Types", Target = new Uri("http://www.amundsen.com/hypermedia/") },
                Description = "Existing hypermedia types"
            });

            _Nodes.Add(new InfoNode()

            {
                Category = "Introduction",
                SubCategory = "Usage",

                Link = new Link() { Title = "Re-distribution of effort", Target = new Uri("https://github.com/RESTFest/2012-greenville/wiki/Hypermedia-Examples") },
                Description = "Intelligent vertical partitioning of functionality across servers."
            });
            _Nodes.Add(new InfoNode()
            {
                Category = "Introduction",
                SubCategory = "Usage",

                Link = new Link() { Title = "Restriction of functionality", Target = new Uri("https://github.com/RESTFest/2012-greenville/wiki/Hypermedia-Examples") },
                Description = "Enabling and disabling features based on the presence of links."
            });

            _Nodes.Add(new InfoNode()
            {
                Category = "Introduction",
                SubCategory = "Usage",

                Link = new Link() { Title = "Reactive applications", Target = new Uri("https://github.com/RESTFest/2012-greenville/wiki/Hypermedia-Examples") },
                Description = "Links to control application flow."
            });



        }

        public IList<InfoNode> GetNodes() {
            return _Nodes;
        } 
    }
}