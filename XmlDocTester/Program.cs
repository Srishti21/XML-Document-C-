using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using DataModelsLib;

namespace XmlDocTester
{
    class Program
    {
        private readonly static string _visitorListXmlFilename = "Visitors.xml";        //Eg. @"C:\Data\Visitors.xml"

        static void Main(string[] args)
        {
            int choice;

            Console.WriteLine("\n****  PROGRAM FOR XML FILE HANDLING IN C# ****\n");

            do
            {
                Console.WriteLine("\n--------------- M E N U ---------------\n");
                Console.WriteLine("Select option for XML File operation : ");
                Console.WriteLine("1. Create/Write file using XmlWriter \n2. Create/Write file using XmlDocument\n3. Display XML file content\n4. Delete file\n5. Exit\n");
                Console.Write("\nEnter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateOrWriteXMLFIleUsingXmlTextWriter();
                        break;

                    case 2:
                        CreateOrWriteXMLFIleUsingXmlDoc();
                        break;

                    case 3:
                        XmlDocument doc = new XmlDocument();
                        if (File.Exists(_visitorListXmlFilename))
                        {
                            doc.Load(_visitorListXmlFilename);
                            string vistorsDoc = PrettyXml(doc.OuterXml);
                            Console.WriteLine("\n"+ vistorsDoc + "\n");
                        }
                        else
                        {
                            Console.WriteLine("\nVisitors.xml file doesn't exist !! First create the file by choosing option 1 or 2.\n");
                        }
                        break;

                    case 4:
                        if (File.Exists(_visitorListXmlFilename))
                        {
                            File.Delete(_visitorListXmlFilename);
                            Console.WriteLine("\nVisitors.xml file deleted successfully !!\n");
                        }
                        else
                        {
                            Console.WriteLine("\nVisitors.xml file doesn't exis t!!\n");
                        }
                        break;

                    case 5:
                        Console.WriteLine("\nExiting... \n");
                        Environment.Exit(-1);
                        break;

                    default:
                        Console.WriteLine("\nWrong Option !!  Select Again. \n");
                        break;
                }
            } while (choice>0 || choice<4);
        }


        public static Visitor EnterVisitorDetails()
        {
            Console.WriteLine("\nEnter visitor details to add in XML file: ");
            Console.Write("ID : ");
            string ID = Console.ReadLine();
            Console.Write("Name : ");
            string Name = Console.ReadLine();
            Console.Write("Date : ");
            string Date = Console.ReadLine();
            Console.Write("Appartment : ");
            string Appartment = Console.ReadLine();
            Console.Write("Phone : ");
            string Phone = Console.ReadLine();
            Console.Write("Intime : ");
            string Intime = Console.ReadLine();

            return new Visitor(ID, Name, Date, Appartment, Phone, Intime);
        }
               

        public static void CreateOrWriteXMLFIleUsingXmlTextWriter()
        {
            if (!File.Exists(_visitorListXmlFilename))
            {
                using (XmlTextWriter writer1 = new XmlTextWriter(_visitorListXmlFilename, System.Text.Encoding.UTF8))
                {
                    writer1.WriteStartDocument(true);
                    writer1.Formatting = Formatting.Indented;
                    writer1.WriteStartElement("Visitors");
                    //Visitor input from user
                    Visitor newVisitor = EnterVisitorDetails();
                    CreateVisitorNodeUsingWriter(newVisitor.ID, newVisitor.Name, newVisitor.Date, newVisitor.Appartment, newVisitor.Phone, newVisitor.InTime, writer1);
                    writer1.WriteEndElement();
                    writer1.WriteEndDocument();
                    writer1.Close();
                    Console.WriteLine("\nVisitors.xml file created and Visitor node added successfully !!\n");
                }
            }
            else
            {
                CreateOrWriteXMLFIleUsingXmlDoc();
            }          
        }


        public static void CreateOrWriteXMLFIleUsingXmlDoc()
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            try
            {
                /*      
                    XmlDocument doc = new XmlDocument();
                   doc.LoadXml("<book>" +
                              "  <title>Oberon's Legacy</title>" +
                              "  <price>5.95</price>" +
                              "</book>"); 
               */

                doc.Load(_visitorListXmlFilename);
                //FindVisitors node
                XmlNode rootNode = doc.SelectSingleNode("Visitors");

                //Visitor input from user
                Visitor newVisitor = EnterVisitorDetails();
                //Create child nodes
                XmlNode userNode = CreateVisitorNodeUsingDoc(newVisitor.ID, newVisitor.Name, newVisitor.Date, newVisitor.Appartment, newVisitor.Phone, newVisitor.InTime, doc);
                rootNode.AppendChild(userNode);
                doc.Save(_visitorListXmlFilename);
                Console.WriteLine("\nVisitor node added successfully !!\n");
            }
            catch (System.IO.FileNotFoundException)
            {
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlNode rootNode = doc.CreateElement("Visitors");
                doc.AppendChild(rootNode);
                doc.InsertBefore(xmlDeclaration, rootNode);

                Visitor newVisitor = EnterVisitorDetails();
                XmlNode userNode = CreateVisitorNodeUsingDoc(newVisitor.ID, newVisitor.Name, newVisitor.Date, newVisitor.Appartment, newVisitor.Phone, newVisitor.InTime, doc);
                rootNode.AppendChild(userNode);

                doc.Save(_visitorListXmlFilename);
                Console.WriteLine("\nVisitors.xml file created and Visitor node added successfully !!\n");
            }
        }


        public static void CreateVisitorNodeUsingWriter(string ID, string Name, string Date, string Appartment, string Phone, string Intime, XmlTextWriter writer)
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


        public static XmlNode CreateVisitorNodeUsingDoc(string ID, string Name, string Date, string Appartment, string Phone, string Intime, XmlDocument doc)
        {
            // Create a new book element.
            XmlNode visitorNode = doc.CreateElement("Visitor");

            // Create and append a child element for the visitor node.
            XmlNode idElement = doc.CreateElement("ID");
            idElement.InnerText = ID;
            visitorNode.AppendChild(idElement);

            // Introduce a newline character so that XML is nicely formatted.
            visitorNode.InnerXml = visitorNode.InnerXml.Replace(idElement.OuterXml, "\n    " + idElement.OuterXml + " \n    ");

            // Create and append a child element for name of the visitor
            XmlNode nameElement = doc.CreateElement("Name");
            nameElement.InnerText = Name;
            visitorNode.AppendChild(nameElement);

            // Introduce a newline character so that XML is nicely formatted.
            visitorNode.InnerXml = visitorNode.InnerXml.Replace(nameElement.OuterXml, nameElement.OuterXml + "   \n  ");

            // Create and append a child element for visiting Date
            XmlNode dateElement = doc.CreateElement("Date");
            dateElement.InnerText = Date;
            visitorNode.AppendChild(dateElement);

            // Introduce a newline character so that XML is nicely formatted.
            visitorNode.InnerXml = visitorNode.InnerXml.Replace(dateElement.OuterXml, dateElement.OuterXml + "   \n  ");

            // Create and append a child element for visiting Appartment
            XmlNode appartmentElement = doc.CreateElement("Appartment");
            appartmentElement.InnerText = Appartment;
            visitorNode.AppendChild(appartmentElement);

            // Introduce a newline character so that XML is nicely formatted.
            visitorNode.InnerXml = visitorNode.InnerXml.Replace(appartmentElement.OuterXml, appartmentElement.OuterXml + "   \n  ");

            // Create and append a child element for visitor's phone no.
            XmlNode phoneElement = doc.CreateElement("Phone");
            phoneElement.InnerText = Phone;
            visitorNode.AppendChild(phoneElement);

            // Introduce a newline character so that XML is nicely formatted.
            visitorNode.InnerXml = visitorNode.InnerXml.Replace(phoneElement.OuterXml, phoneElement.OuterXml + "   \n  ");

            // Create and append a child element for visiting intime
            XmlNode intimeElement = doc.CreateElement("Intime");
            intimeElement.InnerText = Intime;
            visitorNode.AppendChild(intimeElement);

            // Introduce a newline character so that XML is nicely formatted.
            visitorNode.InnerXml = visitorNode.InnerXml.Replace(intimeElement.OuterXml, intimeElement.OuterXml + "   \n  ");

            return visitorNode;
        }


        public static string PrettyXml(string xml)
        {
            var stringBuilder = new StringBuilder();

            var element = XElement.Parse(xml);

            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                element.Save(xmlWriter);
            }

            return stringBuilder.ToString();
        }
    }    
}
