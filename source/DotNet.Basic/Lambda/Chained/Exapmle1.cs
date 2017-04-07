using System;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Lambda.Chained
{

    [TestFixture]
    public class Exapmle1
    {

        public void Run1()
        {
            //string postCode = null;
            //if (person != null && person.Address != null &&
            //    person.Address.PostCode != null)
            //{
            //    postCode = person.Address.PostCode.ToString();
            //}

            var person = new Person();
            string postCode = this.With(x => person)
                      .With(x => x.Address)
                      .With(x => x.PostCode);

            //string postCode2 = this.With(x => person).With(x => x.Address)
            //          .Return(x => x.PostCode, string.Empty);


    //        string postCode3 = this.With(x => person)
    //.If(x => HasMedicalRecord(x))
    //.With(x => x.Address)
    //.Do(x => CheckAddress(x))
    //.With(x => x.PostCode)
    //.Return(x => x.ToString(), "UNKNOWN");

        }


    }

    class Person
    {
        public Address Address { get; set;}

    }

    class Address
    {
        public string PostCode { get; set; }
    }


    public static class ChaineExt
    {
        public static TResult With<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator) where TResult : class where TInput : class
        {
            return o == null ? null : evaluator(o);
        }

        public static TResult Return<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator, TResult failureValue) where TInput : class
        {
            return o == null ? failureValue : evaluator(o);
        }

        public static TInput If<TInput>(this TInput o, Func<TInput, bool> evaluator) where TInput : class
        {
            if (o == null) return null;
            return evaluator(o) ? o : null;
        }

        public static TInput Unless<TInput>(this TInput o, Func<TInput, bool> evaluator) where TInput : class
        {
            if (o == null) return null;
            return evaluator(o) ? null : o;
        }

        public static TInput Do<TInput>(this TInput o, Action<TInput> action) where TInput : class
        {
            if (o == null) return null;
            action(o);
            return o;
        }

        //public static IElement IsWithin<TContainingType>(this IElement self) where TContainingType : class, IElement
        //{
        //    if (self == null) return self;
        //    var owner = self.GetContainingElement<TContainingType>(false);
        //    return owner == null ? self : null;
        //}

        public static TResult WithValue<TInput, TResult>(this TInput o,Func<TInput, TResult> evaluator) where TInput : struct
        {
            return evaluator(o);
        }
    }
}