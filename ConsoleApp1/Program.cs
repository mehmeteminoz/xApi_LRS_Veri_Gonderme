using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinCan;
using TinCan.LRSResponses;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var lrs = new RemoteLRS(
            "https://lrs.adlnet.gov/xAPI/",   //adlnet üzerinde lrs endpointi başka bir lrs de kullanılabilir.
               "username",
               "password"
           );

            var actor = new Agent();
            actor.mbox = "mailto:mehmet_405_18@hotmail.com";

            var verb = new Verb();
            verb.id = new Uri("http://adlnet.gov/expapi/verbs/experienced");
            verb.display = new LanguageMap();
            verb.display.Add("en-US", "experienced");

            var activity = new Activity();
            activity.id = new Uri("http://rusticisoftware.github.io/TinCan.NET").ToString();

            var statement = new Statement();
            statement.actor = actor;
            statement.verb = verb;
            statement.target = activity;

            StatementLRSResponse lrsResponse = lrs.SaveStatement(statement);
            if (lrsResponse.success)
            {
                // Updated 'statement' here, now with id
                Console.WriteLine("Save statement: " + lrsResponse.content.id);
            }
            else
            {
                // Do something with failure
            }

            Console.Read();
        }
    }
}
