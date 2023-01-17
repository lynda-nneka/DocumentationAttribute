using System;
using DocumentationProject;
using System.Reflection;

public class Documentation
{
    public static void GetDocs()
    {
        var assembly = Assembly.GetExecutingAssembly();
        Console.WriteLine("| Code Documentation |");
        Console.WriteLine();
        var types = assembly.GetTypes();

        

        foreach (Type type in types)
        {
            var attributes = type.GetCustomAttributes(typeof(DocumentAttribute), true);

            if (attributes.Length > 0)
            {
                if (type.IsClass)
                {
                    Console.WriteLine("Class: " + type.Name);
                    Console.WriteLine("\tDescription: " + ((DocumentAttribute)attributes[0]).Description);
                    Console.WriteLine();


                    foreach (ConstructorInfo constructor in type.GetConstructors())
                    {
                        var constructorAttributes = constructor.GetCustomAttributes(typeof(DocumentAttribute), true);
                        if (constructorAttributes.Length > 0)
                        {
                            Console.WriteLine("Constructor: " + constructor.Name);
                            Console.WriteLine("\tDescription: " + ((DocumentAttribute)constructorAttributes[0]).Description);
                            Console.WriteLine("\tInput: " + ((DocumentAttribute)constructorAttributes[0]).Input);
                            Console.WriteLine();
                        }
                    }

                    foreach (MethodInfo method in type.GetMethods())
                    {
                        var methodAttributes = method.GetCustomAttributes(typeof(DocumentAttribute), true);
                        if (methodAttributes.Length > 0)
                        {
                            Console.WriteLine("Method: " + method.Name);
                            Console.WriteLine("\tDescription: " + ((DocumentAttribute)methodAttributes[0]).Description); 
                            Console.WriteLine("\tInput: " + ((DocumentAttribute)methodAttributes[0]).Input);
                            Console.WriteLine("\tOutput: " + ((DocumentAttribute)methodAttributes[0]).Output);
                            Console.WriteLine();
                        }
                    }

                    foreach (PropertyInfo property in type.GetProperties())
                    {
                        var propertyAttributes = property.GetCustomAttributes(typeof(DocumentAttribute), true);
                        if (propertyAttributes.Length > 0)
                        {
                            Console.WriteLine("Property: " + property.Name);
                            Console.WriteLine("\tDescription: " + ((DocumentAttribute)propertyAttributes[0]).Description);
                            Console.WriteLine("\tOutput: " + ((DocumentAttribute)propertyAttributes[0]).Output);
                            Console.WriteLine();
                        }
                    }

                   }

                   if (type.IsEnum)
                  {
                    Console.WriteLine("Enum: " + type.Name);
                    Console.WriteLine("\tDescription: " + ((DocumentAttribute?)attributes.SingleOrDefault(a => a.GetType()== typeof(DocumentAttribute)))?.Description);
                    
                    string[] names = type.GetEnumNames();
                    foreach (string name in names)
                    {
                        Console.WriteLine(name);
                        
                    }
                    Console.WriteLine();
                 }

            }

        }
        Console.WriteLine("| End of Documentation |");
        Console.WriteLine();

    }

}

            