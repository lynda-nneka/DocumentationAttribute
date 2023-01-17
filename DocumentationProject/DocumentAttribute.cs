using System;
namespace DocumentationProject
{
    [AttributeUsage(AttributeTargets.All)]
    public class DocumentAttribute : Attribute
    {
        public string Description { get; }
        public string Input { get; }
        public string Output { get; }

        public DocumentAttribute(string description, string input = "", string output = "")
        {
            Description = description;
            Input = input;
            Output = output;
        }
    }
}

