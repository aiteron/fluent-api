﻿using System.Globalization;
using NUnit.Framework;

namespace ObjectPrinting.Tests
{
    [TestFixture]
    public class ObjectPrinterAcceptanceTests
    {
        [Test]
        public void Demo()
        {
            var person = new Person { Name = "Alex", Age = 19 };

            var printer = ObjectPrinter.For<Person>()
                //1. Исключить из сериализации свойства определенного типа
                .Exclude<int>()
                //2. Указать альтернативный способ сериализации для определенного типа
                .SetAltSerialize<double>().Using(i => i.ToString())
                //3. Для числовых типов указать культуру
                .SetAltSerialize<float>().Using(CultureInfo.CurrentCulture)
                //4. Настроить сериализацию конкретного свойства
                .SetAltSerialize(p => p.Name).Using(i => i.ToString())
                //5. Настроить обрезание строковых свойств (метод должен быть виден только для строковых свойств)
                .SetAltSerialize(p => p.Name).TrimmedToLength(10)
                //6. Исключить из сериализации конкретного свойства
                .Exclude(p => p.Name);

            string s1 = printer.PrintToString(person);

            //7. Синтаксический сахар в виде метода расширения, сериализующего по-умолчанию        
            //8. ...с конфигурированием
        }
    }
}