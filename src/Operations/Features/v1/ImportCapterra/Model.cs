using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations.Features.v1.ImportCapterra
{
    public class Model
    {
        public IEnumerable<Product> Products { get; set; }
    }

    public class Product
    {
        public string Tags { get; set; }
        public string Name { get; set; }
        public string Twitter { get; set; }
    }
    //    ---
    //-
    //  tags: "Bugs & Issue Tracking,Development Tools"
    //  name: "GitGHub"
    //  twitter: "github"
    //-
    //  tags: "Instant Messaging & Chat,Web Collaboration,Productivity"
    //  name: "Slack"
    //  twitter: "slackhq"
    //-
    //  tags: "Project Management,Project Collaboration,Development Tools"
    //  name: "JIRA Software"
    //  twitter: "jira"
}
