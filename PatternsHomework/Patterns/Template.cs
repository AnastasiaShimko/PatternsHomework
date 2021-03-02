using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatternsHomework.Patterns
{
    public abstract class AbstractClass
    {
        public string TemplateMethod()
        {
            var result = "";
            result += this.BaseOperation1();
            result += this.RequiredOperations1();
            result += this.BaseOperation2();
            result += this.Hook1();
            result += this.RequiredOperation2();
            result += this.BaseOperation3();
            this.Hook2();

            return result;
        }

        protected string BaseOperation1()
        {
            return "AbstractClass says: I am doing the bulk of the work. ";
        }

        protected string BaseOperation2()
        {
            return "AbstractClass says: But I let subclasses override some operations. ";
        }

        protected string BaseOperation3()
        {
            return "AbstractClass says: But I am doing the bulk of the work anyway. ";
        }

        protected abstract string RequiredOperations1();

        protected abstract string RequiredOperation2();

        protected virtual string Hook1()
        {
            return "";

        }

        protected virtual void Hook2() { }
    }

    class ConcreteClass1 : AbstractClass
    {
        protected override string RequiredOperations1()
        {
            return "ConcreteClass1 says: Implemented Operation1. ";
        }

        protected override string RequiredOperation2()
        {
            return "ConcreteClass1 says: Implemented Operation2. ";
        }
    }

    class ConcreteClass2 : AbstractClass
    {
        protected override string RequiredOperations1()
        {
            return "ConcreteClass2 says: Implemented Operation1. ";
        }

        protected override string RequiredOperation2()
        {
            return "ConcreteClass2 says: Implemented Operation2. ";
        }

        protected override string Hook1()
        {
            return "ConcreteClass2 says: Overridden Hook1. ";
        }
    }
}
