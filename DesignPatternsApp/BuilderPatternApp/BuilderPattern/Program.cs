using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    internal class Program
    {
        public class HtmlElement
        {
            public string Name, Text;
            public List<HtmlElement> Elements = new List<HtmlElement>();
            private const int indentSize = 2;

            public HtmlElement()
            {

            }

            public HtmlElement(string name, string text)
            {
                Name = name;
                Text = text;
            }

            private string ToStringImpl(int intent)
            {
                var sb = new StringBuilder();
                var i = new string(' ', indentSize * intent);
                sb.AppendLine($"{i}<{Name}>");

                if (!string.IsNullOrWhiteSpace(Text))
                {
                    sb.Append(new string(' ', indentSize * (intent + 1)));
                    sb.AppendLine(Text);
                }

                foreach (var e in Elements)
                {
                    sb.Append(e.ToStringImpl(intent + 1));
                }
                sb.AppendLine($"{i}</{Name}>");

                return sb.ToString();
            }


            public override string ToString()
            {
                return ToStringImpl(0);
            }

        }

        public class HtmlBuilder
        {
            private readonly string rootName;
            HtmlElement root = new HtmlElement();

            public HtmlBuilder(string rootName)
            {
                this.rootName = rootName;
                root.Name = rootName;
            }

            public void AddChild(string childName, string childText)
            {
                var e = new HtmlElement(childName, childText);
                root.Elements.Add(e);
            }

            public void Clear()
            {
                root = new HtmlElement();
            }
            public override string ToString()
            {
                return root.ToString();
            }

        }

        static void Main(string[] args)
        {


            var sb = new StringBuilder();
            var words = new[] { "hello", "world" };
            sb.AppendLine("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.AppendLine("</ul>");

            Console.WriteLine(sb.ToString());

            var htmlBuilder=new HtmlBuilder("ul");
            htmlBuilder.AddChild("li","Mahfuz");
            htmlBuilder.AddChild("li","Shazol");
            htmlBuilder.AddChild("li","Rahman");

            Console.WriteLine(htmlBuilder.ToString());


        }
    }
}
