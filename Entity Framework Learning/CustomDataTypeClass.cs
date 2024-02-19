using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Learning
{
    public class CustomDataTypeClass
    {


        /// <summary>
        /// Creates a dynamic object based on an anonymous object that you create.
        /// </summary>
        public void createMyType()
        {
            var record = new { BN = "11234", FPE = "id123" };

            // Create a new assembly and module
            AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");

            // Create a new type builder
            TypeBuilder typeBuilder = moduleBuilder.DefineType("RecordType", TypeAttributes.Public);

            // Define properties in the type based on the properties of the anonymous type
            foreach (var property in record.GetType().GetProperties())
            {
                FieldBuilder fieldBuilder = typeBuilder.DefineField("_" + property.Name, property.PropertyType, FieldAttributes.Private);

                PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(property.Name, PropertyAttributes.None, property.PropertyType, null);

                MethodBuilder getMethodBuilder = typeBuilder.DefineMethod("get_" + property.Name,
                    MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                    property.PropertyType, Type.EmptyTypes);
                ILGenerator getILGenerator = getMethodBuilder.GetILGenerator();
                getILGenerator.Emit(OpCodes.Ldarg_0);
                getILGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
                getILGenerator.Emit(OpCodes.Ret);

                MethodBuilder setMethodBuilder = typeBuilder.DefineMethod("set_" + property.Name,
                    MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                    null, new[] { property.PropertyType });
                ILGenerator setILGenerator = setMethodBuilder.GetILGenerator();
                setILGenerator.Emit(OpCodes.Ldarg_0);
                setILGenerator.Emit(OpCodes.Ldarg_1);
                setILGenerator.Emit(OpCodes.Stfld, fieldBuilder);
                setILGenerator.Emit(OpCodes.Ret);


                propertyBuilder.SetGetMethod(getMethodBuilder);
                propertyBuilder.SetSetMethod(setMethodBuilder);

                //Console.WriteLine($"IsGenericMethod {getMethodBuilder.IsGenericMethod}");
                //Console.WriteLine($"IsGenericMethod {setMethodBuilder.IsGenericMethod}");

            }

            // Create the type
            Type dynamicType = typeBuilder.CreateType();

            // Instantiate the dynamic type
            object dynamicObject = Activator.CreateInstance(dynamicType);
            //Console.WriteLine(dynamicType.GetProperty("BN").GetValue(dynamicObject));

            // Set property values
            foreach (var property in record.GetType().GetProperties())
            {
                PropertyInfo dynamicProperty = dynamicType.GetProperty(property.Name);

                dynamicProperty.SetValue(dynamicObject, property.GetValue(record));
                //Console.WriteLine(dynamicType.GetProperty("BN").GetValue(dynamicObject));

            }

            // Test
            Console.WriteLine(dynamicType.GetProperty("BN").GetValue(dynamicObject));
            Console.WriteLine(dynamicType.GetProperty("FPE").GetValue(dynamicObject));

            string a = dynamicType.GetProperty("BN").GetValue(dynamicObject).ToString();
            Console.WriteLine(a);

        }
    }
}
