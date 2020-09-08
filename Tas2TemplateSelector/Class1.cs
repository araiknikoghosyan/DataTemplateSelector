using System;
using System.Transactions;
namespace Tas2TemplateSelector
{
    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }
    public class Class1
    {
        public string itemType { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public Detail[] details { get; set; }
        public override string ToString()
        {
            return $"{itemType}{type}{title}{details}";
        }
    }
    public class Detail : Class1
    {
        public string detail_type { get; set; }
        public string itemType { get; set; }
        public string fill_color { get; set; }
        public Gradient_Props gradient_props { get; set; }
        public string icon_url { get; set; }
        public string resource_url { get; set; }
        public override string ToString()
        {
            return $"{detail_type}{title}{type}";
        }
    }
    public class Color : Detail
    {
        public Color()
        {

        }
        public Color(string color)
        {
            this.fill_color = color;
        }
    }
    public class Icon : Detail
    {
        public Icon()
        {

        }
        public Icon(string icon)
        {
            this.icon_url = icon;
        }
    }
    public class Gradient_Props : Class1
    {
        public string gradient_stop_1 { get; set; }
        public string gradient_stop_2 { get; set; }
    }
}
