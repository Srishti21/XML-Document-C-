using System;
using System.Xml;

namespace XmlDocTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //    XmlDocument xmlDoc = new XmlDocument();
            //    XmlNode rootNode = xmlDoc.CreateElement("visitors");
            //    xmlDoc.AppendChild(rootNode);

            //    XmlNode userNode = xmlDoc.CreateElement("visitor");
            //    XmlAttribute attribute = xmlDoc.CreateAttribute("age");
            //    attribute.Value = "42";
            //    userNode.Attributes.Append(attribute);
            //    userNode.InnerText = "John Doe";
            //    rootNode.AppendChild(userNode);

            //    userNode = xmlDoc.CreateElement("visitor");
            //    attribute = xmlDoc.CreateAttribute("age");
            //    attribute.Value = "39";
            //    userNode.Attributes.Append(attribute);
            //    userNode.InnerText = "Jane Doe";
            //    rootNode.AppendChild(userNode);

            //    xmlDoc.Save("C:\\Data\\test1.xml");


            /*
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml("<book>" +
                               "  <title>Oberon's Legacy</title>" +
                               "  <price>5.95</price>" +
                               "</book>"); 

                   // Create a new element node.
                   XmlNode newElem = doc.CreateNode("element", "pages", "");
                    newElem.InnerText = "290";

                   Console.WriteLine("Add the new element to the document...");
                   XmlElement root = doc.DocumentElement;
                    root.AppendChild(newElem);

                   Console.WriteLine("Display the modified XML document...");
                   Console.WriteLine(doc.OuterXml);

                */




            // Create the XmlDocument.
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode = doc.CreateElement("Visitors");
            doc.AppendChild(rootNode);
            XmlNode userNode = doc.CreateElement("Visitor");
            rootNode.AppendChild(userNode);

            XmlNode id = doc.CreateElement("id");
            id.InnerText = "1";
            userNode.AppendChild(id);

            XmlNode name = doc.CreateElement("name");
            name.InnerText = "19.95";
            userNode.AppendChild(name);

            XmlNode date = doc.CreateElement("date");
            date.InnerText = "19.95";
            userNode.AppendChild(date);

            XmlNode appartment = doc.CreateElement("appartment");
            appartment.InnerText = "19.95";
            userNode.AppendChild(appartment);

            XmlNode phone = doc.CreateElement("phone");
            phone.InnerText = "19.95";
            userNode.AppendChild(phone);

            XmlNode intime = doc.CreateElement("intime");
            intime.InnerText = "19.95";
            userNode.AppendChild(intime);


            rootNode.AppendChild(userNode);

            

            //doc.LoadXml("<item><name>wrench</name></item>"); //Your string here

            // Save the document to a file and auto-indent the output.
            XmlTextWriter writer = new XmlTextWriter("data.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);




            using (XmlTextWriter writer1 = new XmlTextWriter("product.xml", System.Text.Encoding.UTF8))
            {
                writer1.WriteStartDocument(true);
                writer1.Formatting = Formatting.Indented;
                writer1.WriteStartElement("Visitors");
                CreateNode("1", "Srish", "12/02/23", "xyz", "770923832", "10", writer1);
                CreateNode("2", "Mallika", "11/12/23", "abc", "98342143", "11", writer1);
                CreateNode("3", "Arpita", "23/02/24", "def", "74563521131", "23", writer1);
                CreateNode("4", "Devishi", "12/102/24", "ghi", "898653541", "12", writer1);
                CreateNode("5", "Mona", "12/02/23", "jkl", "987564322", "09", writer1);
                writer1.WriteEndElement();
                writer1.WriteEndDocument();
                writer1.Close();
                Console.WriteLine("\n\nXML File created ! ");
            }

        }

        public static void CreateNode(string ID, string Name, string Date, string Appartment, string Phone, string Intime, XmlTextWriter writer)
        {
            writer.WriteStartElement("Visitor");
            writer.WriteStartElement("ID");
            writer.WriteString(ID);
            writer.WriteEndElement();
            writer.WriteStartElement("Name");
            writer.WriteString(Name);
            writer.WriteEndElement();
            writer.WriteStartElement("Date");
            writer.WriteString(Date);
            writer.WriteEndElement();
            writer.WriteStartElement("Appartment");
            writer.WriteString(Appartment);
            writer.WriteEndElement();
            writer.WriteStartElement("Phone");
            writer.WriteString(Phone);
            writer.WriteEndElement();
            writer.WriteStartElement("Intime");
            writer.WriteString(Intime);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }

    
}
