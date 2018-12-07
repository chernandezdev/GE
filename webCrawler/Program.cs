using System;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace webCrawler
{
    class Program
    {
        static void Main(string[] args)
        {         
            Internet internet1 = new Internet();
            Internet internet2 = new Internet();
            //Map JSON strings to Internet objects
            Parallel.Invoke
            (
                () => internet1 = internet1.CreateInternet(Constants.json1),
                () => internet2 = internet2.CreateInternet(Constants.json2)
            );
            InternetResults internetResults1 = new InternetResults();
            InternetResults internetResults2 = new InternetResults();
            //Run both crawls
            Parallel.Invoke
            (
                () => internetResults1 = crawlInternet(internet1),
                () => internetResults2 = crawlInternet(internet2)
            );                
            Console.WriteLine(Constants.resultsText + "1");
            DisplayResults(internetResults1);
            Console.WriteLine(Constants.resultsText + "2");
            DisplayResults(internetResults2);
        }

        //Generates a list of valid addresses for a given Internet
        public static List<string> GetAddresses(Internet internet)
        {
            List<string> ValidAdresses = new List<string>();
            foreach (var website in internet.pages)
            {
                ValidAdresses.Add(website.address);
            }

            return ValidAdresses;

        }

        public static InternetResults crawlInternet(Internet internet)
        {
            InternetResults internetResults = new InternetResults();
            internetResults.InternetValid = new List<string>();
            internetResults.InternetInvalid = new List<string>();
            internetResults.InternetDuplicate = new List<string>();
            List<string> ValidAdresses = new List<string>();
            //Use this list to determine if link is valid
            ValidAdresses = GetAddresses(internet);
            foreach (var page in internet.pages)
            {
                foreach (var link in page.links)
                {
                    //Check to see if Link is valid first
                    if (ValidAdresses.Contains(link))
                    {
                        //Check to see if this site has been visited
                        if (!internetResults.InternetValid.Contains(link))
                        {
                            internetResults.InternetValid.Add(link);
                        }
                        //This site does not need to be visited
                        else
                        {
                            internetResults.InternetDuplicate.Add(link);
                        }

                    }
                    //Invalid URL
                    else 
                    {
                        internetResults.InternetInvalid.Add(link);
                    }
                }

            }
            return internetResults;
        }

        public static void DisplayResults(InternetResults internetResults)
        {
            if (internetResults.InternetValid != null && internetResults.InternetValid.Any())
            {
                Console.WriteLine("\nSuccessful Links:\n");
                foreach (var link in internetResults.InternetValid.Distinct())
                {
                    Console.WriteLine("\n"+ link +"\n");
                }
            }
            else { Console.WriteLine("\nNo Successful Links"); }

            if (internetResults.InternetDuplicate != null && internetResults.InternetDuplicate.Any())
            {
                Console.WriteLine("\nSkipped Links:\n");
                foreach (var link in internetResults.InternetDuplicate.Distinct())
                {
                    Console.WriteLine("\n"+ link +"\n");
                }
            }
            else { Console.WriteLine("\nNo Skipped Links"); }

            if (internetResults.InternetInvalid != null && internetResults.InternetInvalid.Any())
            {
                Console.WriteLine("\nInvalid Links:\n");
                foreach (var link in internetResults.InternetInvalid.Distinct())
                {
                    Console.WriteLine("\n"+ link +"\n");
                }
            }
            else { Console.WriteLine("\nNo Invalid Links"); }

        }


    }

}
