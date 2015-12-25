using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ImageManipulation.TabsNS.ImageOperationsNS
{
    class MethodData
    {
        static string fileName = "C:\\Temp\\tasks.xml";

        public static ObservableCollection<Method> GetTasks()
        {
            ObservableCollection<Method> tasks = new ObservableCollection<Method>();
            if (System.IO.File.Exists(fileName))
            {
                XDocument xDocument = XDocument.Load(fileName);

                var data = from item in xDocument.Descendants("task")
                           select new
                           {
                               id = new Guid(item.Attribute("ID").Value),
                               name = item.Element("Name").Value,
                               description = item.Element("Description").Value,
                               isImportant = Convert.ToBoolean(item.Element("IsImportant").Value),
                               sliderValues = item.Element("SliderValues").Value,
                               //blueSliderValue = Convert.ToInt32(item.Element("BlueSliderValue").Value),
                               //greenSliderValue = Convert.ToInt32(item.Element("GreenSliderValue").Value),
                               //redSliderValue = Convert.ToInt32(item.Element("RedSliderValue").Value),

                               //strongSliderValue = Convert.ToInt32(item.Element("StrongSliderValue").Value),
                               //middleSliderValue = Convert.ToInt32(item.Element("MiddleliderValue").Value),
                               //weakSliderValue = Convert.ToInt32(item.Element("WeakSliderValue").Value),
                              

                           };
                foreach (var item in data)
                {
                    Method t = new Method();
                    t.ID = item.id;
                    t.Name = item.name;
                    t.Description = item.description;
                    t.IsImportant = item.isImportant;
                    t.SliderValues = item.sliderValues;
                    t.ConvertSliderValues();
                    //t.BlueSliderValue = item.blueSliderValue;
                    //t.GreenSliderValue = item.greenSliderValue;
                    //t.RedSliderValue = item.redSliderValue;
                    //t.StrongSliderValue = item.strongSliderValue;
                    //t.MiddleSliderValue = item.middleSliderValue;
                    //t.WeakSliderValue = item.weakSliderValue; 
                    tasks.Add(t);
                }
            }
            else
            {
                CreateXMLFile();
            }

            return tasks;
        }

        public static void AddTask(Method task)
        {
            XmlDocument document = new XmlDocument();
            document.Load(fileName);

            XmlNode taskElement = document.CreateElement("task");
            document.DocumentElement.AppendChild(taskElement);
            XmlAttribute attribute = document.CreateAttribute("ID");
            attribute.Value = (task.ID).ToString();
            taskElement.Attributes.Append(attribute);

            XmlNode taskName = document.CreateElement("Name");
            taskName.InnerText = task.Name;
            taskElement.AppendChild(taskName);

            XmlNode taskDescription = document.CreateElement("Description");
            taskDescription.InnerText = task.Description;
            taskElement.AppendChild(taskDescription);

            XmlNode taskIsImportant = document.CreateElement("IsImportant");
            taskIsImportant.InnerText = task.IsImportant.ToString();
            taskElement.AppendChild(taskIsImportant);

            XmlNode taskSliderValues = document.CreateElement("SliderValues");
            taskSliderValues.InnerText = task.SliderValues;
            taskElement.AppendChild(taskSliderValues);

            //XmlNode taskGreenSliderValue = document.CreateElement("GreenSliderValue");
            //taskGreenSliderValue.InnerText = task.GreenSliderValue.ToString();
            //taskElement.AppendChild(taskGreenSliderValue);

            //XmlNode taskRedSliderValue = document.CreateElement("RedSliderValue");
            //taskRedSliderValue.InnerText = task.RedSliderValue.ToString();
            //taskElement.AppendChild(taskRedSliderValue);

            //XmlNode taskStrongSliderValue = document.CreateElement("StrongSliderValue");
            //taskStrongSliderValue.InnerText = task.StrongSliderValue.ToString();
            //taskElement.AppendChild(taskStrongSliderValue);

            //XmlNode taskMiddleSliderValue = document.CreateElement("MiddleSliderValue");
            //taskMiddleSliderValue.InnerText = task.MiddleSliderValue.ToString();
            //taskElement.AppendChild(taskMiddleSliderValue);

            //XmlNode taskWeakSliderValue = document.CreateElement("WeakSliderValue");
            //taskWeakSliderValue.InnerText = task.WeakSliderValue.ToString();
            //taskElement.AppendChild(taskWeakSliderValue);

            document.Save(fileName);



        }

        private static void CreateXMLFile()
        {
            XmlTextWriter textWriter = new XmlTextWriter(fileName, Encoding.UTF8);
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("head");
            textWriter.WriteEndElement();
            textWriter.Close();
        }

        public static void DeleteTask(Method task)
        {
            XDocument xDocument = XDocument.Load(fileName);
            xDocument.Descendants("head").Elements("task").First(x => x.Attribute("ID").Value == task.ID.ToString())
                .Remove();
            xDocument.Save(fileName);
        }

        public static void UpdateTask(Method task)
        {
            XDocument xDocument = XDocument.Load(fileName);
            var item = xDocument.Descendants("head")
                                .Elements("task")
                                .First(x => x.Attribute("ID").Value == task.ID.ToString());
            item.SetElementValue("Name", task.Name);
            item.SetElementValue("Description", task.Description);
            item.SetElementValue("IsImportant", task.IsImportant);
            item.SetElementValue("SliderValues", task.SliderValues);
            //item.SetElementValue("BlueSliderValue", task.BlueSliderValue);
            //item.SetElementValue("GreenSliderValue", task.GreenSliderValue);
            //item.SetElementValue("RedSliderValue", task.RedSliderValue);

            //item.SetElementValue("StrongSliderValue", task.StrongSliderValue);
            //item.SetElementValue("MiddleSliderValue", task.MiddleSliderValue);
            //item.SetElementValue("WeakSliderValue", task.WeakSliderValue);

            xDocument.Save(fileName);
        }
    }
}
