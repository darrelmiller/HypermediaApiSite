using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using HypermediaApiSiteConsole.Model;
using HypermediaApiSiteConsole.Tools;
using HypermediaApiSiteConsole.ViewEngine;
using Microsoft.Data.OData;
using Microsoft.Data.OData.Atom;
using Tavis;
using System.Linq;

namespace HypermediaApiSiteConsole.Root.Learning
{
    public class LearningViewModel : IViewEngineView, IPlainTextView, IODataView
    {

        public string PageTitle { get; set; }
        public List<InfoNode> Videos { get; set; }
        public List<InfoNode> Community { get; set; }
        public List<InfoNode> BlogPosts { get; set; }

        public LearningViewModel(InfoRepository infoRepository) {

            PageTitle = "Learning";

            Community = new List<InfoNode>();

            Videos = (from i in infoRepository.GetNodes()
                      where i.Category == "Learning" && i.SubCategory == "Videos"
                      select i).ToList();


            Community = (from i in infoRepository.GetNodes()
                      where i.Category == "Learning" && i.SubCategory == "Community"
                      select i).ToList();

        }


        View IViewEngineView.CreateView()
        {
            var template = this.GetType().Assembly.GetManifestResourceStream(this.GetType(), "LearningView.cshtml");

            var view = new View(template, this);

            return view;

        }


        ODataResponse IODataView.CreateView()
        {
            var oDataResponse = new ODataResponse();
            var messageWriter = new ODataMessageWriter(oDataResponse);
  
            var entryWriter = messageWriter.CreateODataFeedWriter();
            var feed = new ODataFeed() { Count = Videos.Count, Id = "Hypermedia-Learning" };
            var atomFeed = feed.Atom();
            atomFeed.Title = "Hypermedia API - " + PageTitle;
            
            entryWriter.WriteStart(feed);
            foreach (var video in Videos)
            {
                var oDataEntry = new ODataEntry() {};
                var atom = oDataEntry.Atom();
                
                atom.Title = "Video : " + video.Link.Title;
                atom.Summary = video.Description;
                entryWriter.WriteStart(oDataEntry);

                entryWriter.WriteEnd();   
                
            }

            foreach (var item in Community)
            {
                var oDataEntry = new ODataEntry() { };
                var atom = oDataEntry.Atom();

                atom.Title = "Community : " + item.Link.Title;
                atom.Summary = item.Description;
                entryWriter.WriteStart(oDataEntry);

                entryWriter.WriteEnd();

            }

            entryWriter.WriteEnd();
            entryWriter.Flush();
            oDataResponse.GetStream().Position = 0;
            return oDataResponse;
        }
        string IPlainTextView.CreateView()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Videos");
            foreach (var video in Videos)
            {
                sb.AppendLine(video.Link.Target.OriginalString);
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

    public class ODataResponse : IODataResponseMessage {

        private MemoryStream _Stream = new MemoryStream();
        private Dictionary<string, string>  _Headers = new Dictionary<string, string>();
        public ODataResponse() {
            Headers = new Dictionary<string, string>();
        }
        public string GetHeader(string headerName) {
            string value;
            if (_Headers.TryGetValue(headerName, out value))
            {
                return value;
            }

            return null;
        }

        public void SetHeader(string headerName, string headerValue) {
            ((Dictionary<string, string>) _Headers)[headerName] = headerValue;
        }

        public Stream GetStream() {
            return _Stream;
        }

        public IEnumerable<KeyValuePair<string, string>> Headers { get; private set; }
        public int StatusCode { get; set; }
    }
}
