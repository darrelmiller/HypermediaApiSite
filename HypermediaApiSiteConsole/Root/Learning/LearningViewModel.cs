using System;
using System.Collections.Generic;
using System.Text;
using HypermediaApiSiteConsole.Tools;
using HypermediaApiSiteConsole.ViewEngine;
using Tavis;

namespace HypermediaApiSiteConsole.Root.Learning
{
    public class LearningViewModel : IViewEngineView, IPlainTextView
    {

        public List<Link> Videos { get; set; }
        public List<InfoNode> Community { get; set; }
        public List<Link> BlogPosts { get; set; }

        public LearningViewModel() {
            Videos = new List<Link>();
            Community = new List<InfoNode>();
            BlogPosts = new List<Link>();

            Videos.Add(new Link() {
                                      Target = new Uri("http://oredev.org/2010/sessions/hypermedia-apis"),
                                      Title = "Hypermedia APIs - Jon Moore"
                                  });
            Videos.Add(new Link() {
                                      Target = new Uri("http://www.infoq.com/presentations/Hypermedia-Web-Integration"),
                                      Title = "The Role of Hypermedia and the Future of Web Integration - Guilherme Silveira"
                                  });
            Videos.Add(new Link() {
                                      Target = new Uri("http://oredev.org/2010/sessions/hypermedia-apis"),
                                      Title = "Hypermedia APIs - Jon Moore"
                                  });


            Community.Add(new InfoNode() {
                                             Link = new Link() {
                                                                   Target =
                                                                       new Uri(
                                                                       "https://groups.google.com/forum/?fromgroups#!forum/hypermedia-web"),
                                                                   Title = "Hypermedia Web - Google Groups"
                                                               },
                                             Description =
                                                 "Mike Amundsen's list covering all things hypermedia related."
                                         });
            Community.Add(new InfoNode() {
                                             Link = new Link() {
                                                                   Target =
                                                                       new Uri(
                                                                       "https://groups.google.com/forum/?fromgroups#!forum/api-craft"),
                                                                   Title = "Api-Craft - Google Groups"
                                                               },
                                             Description =
                                                 "Mailing list managed by Apigee on subjects related to building and designing Web APIs."
                                         });

            Community.Add(new InfoNode() {
                                             Link = new Link() {
                                                                   Target =
                                                                       new Uri(
                                                                       "http://tech.groups.yahoo.com/group/rest-discuss/"),
                                                                   Title = "REST Discuss - Yahoo Groups"
                                                               },
                                             Description =
                                                 "The original home of the REST community.  Not exactly friendly for newcomers but the place to go when you want to hear an authoritative answer"
                                         });


            Community.Add(new InfoNode() {
                                             Link = new Link() {
                                                                   Target = new Uri("irc://freenode.net#rest"),
                                                                   Title = "REST IRC Channel"
                                                               },
                                             Description =
                                                 "Informal and generally friendly, this is great place to bounce an idea of some knowlegable people."
                                         });
        }


        View IViewEngineView.CreateView()
        {
            var template = this.GetType().Assembly.GetManifestResourceStream(this.GetType(), "LearningView.cshtml");

            var view = new View(template, this);

            return view;

        }


        string IPlainTextView.CreateView()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Videos");
            foreach (var video in Videos)
            {
                sb.AppendLine(video.Target.OriginalString);
            }
            sb.AppendLine("Community");
            foreach (var infoNode in Community)
            {
                sb.AppendLine(infoNode.Link.Title);
                sb.AppendLine(infoNode.Link.Target.OriginalString);
                sb.AppendLine(infoNode.Description);
                sb.AppendLine("");
            }
            sb.AppendLine("Articles");

            return sb.ToString();
        }
    }

    public class InfoNode
    {
        public String Title { get; set; }
        public Link Link { get; set; }
        public string Description { get; set; }
    }
}
