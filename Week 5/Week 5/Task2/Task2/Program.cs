using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Mark> midResults = new List<Mark>
            {
                new Mark(27),
                new Mark(97),
                new Mark(78),
                new Mark(89),
                new Mark(62),
                new Mark(53),
                new Mark(81)
            };

            using (Stream fs = new FileStream(@"C:\Users\Admin\Desktop\PP2\Week 5\Week 5\Task2\Task2\bin\Debug\marks.xml", 
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Mark>));
                serializer.Serialize(fs, midResults);
            }

            midResults = null;
            XmlSerializer serializer2 = new XmlSerializer(typeof(List<Mark>));
            using (FileStream fs2 = File.OpenRead(@"C:\Users\Admin\Desktop\PP2\Week 5\Week 5\Task2\Task2\bin\Debug\marks.xml"))
            {
                midResults = (List<Mark>)serializer2.Deserialize(fs2);
            }

            foreach( Mark m in midResults)
            {
                Console.WriteLine(m.ToString());
            }
        }
    }
}
