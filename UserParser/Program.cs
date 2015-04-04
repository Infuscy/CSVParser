using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UserParser
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument userDoc = new XmlDocument();
            userDoc.Load(@"C:\Users\Florin\Desktop\xml-uril comentarii&useri&regiuni\UserFinal.xml");

            XmlNodeList xmlNodeList = userDoc.SelectNodes("//users/user");

            Dictionary<string, int> userCategories = new Dictionary<string, int>();

            foreach(XmlNode xmlNode in xmlNodeList)
            {
                string category = xmlNode.Attributes["user_type"].Value;
                if(userCategories.ContainsKey(category))
                {
                    int numberOfUsers = userCategories[category];

                    userCategories[category] = numberOfUsers + 1;
                }
                else
                {
                    userCategories.Add(category, 1);
                }
                    
            }

            string temp = null;
            foreach(var item in userCategories.ToList())
            {
                temp += item.Key + " " + item.Value + "\n";
            }
            File.AppendAllText(@"C:\Users\Florin\Desktop\xml-uril comentarii&useri&regiuni\Users.csv", temp);
        }
    }
}
