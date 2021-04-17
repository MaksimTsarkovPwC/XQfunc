using System;
using System.Xml;
using System.Linq;
using System.Xml.XPath;
using System.Xml.Linq;

namespace xmlParser
{

    class Program
    {
        private static void PrintSelectedNodeText(XmlNode x, string xp, int depth, int num)
        {
            foreach (XmlNode i in x)
            {
                if (i.Name == xp.Split('/')[depth - num])
                {
                    if (num == 1)
                    {
                        Console.WriteLine(i.InnerText);
                        break;
                    }
                    else
                    {
                        num = num - 1;
                        PrintSelectedNodeText(i, xp, depth, num);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //xp is path to wanted node without /ED_Container/
            var xp = "ContainerDoc/DocBody/ESADout_CU/ESADout_CUGoodsShipment/ESADout_CUConsigment/ESADout_CUDepartureArrivalTransport/cat_ru:TransportModeCode";

            XmlDocument doc = new XmlDocument();
            //doc.load("path to xml document"); 
            doc.Load("C:/Users/mtsarkov001/Documents/Container_10005030_221120_0356760.XML");
            //depth of wanted node
            int depth = xp.Split('/').Length;
            //function that print wanted node text
            PrintSelectedNodeText(doc.DocumentElement, xp, depth, depth);
            Console.ReadKey();
        }
    }
}

