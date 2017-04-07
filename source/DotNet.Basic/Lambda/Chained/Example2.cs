using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Lambda.Chained
{

    [TestFixture]
    public class Example2
    {
        public void Run1()
        {
            var p1 = "test";

            //var result = Valiadter<int>("p1", p1).NotNull().LongerThan(3).IsNumberic();


            //var rst = new Result<Sample>();
            //rst.Validate(p1 ).NotEmpty("erro has happy");




        }
    }


    public static class CheckExt
    {


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
    }



    class Result<TInstance>
    {
        private ValidMessage _messages;
        /// <summary>
        /// 
        /// </summary>
        public ValidMessage Message => _messages ?? (_messages = new ValidMessage());

        public int Code { get; set; }

        public bool HasMessage => Message.Count > 0;

        public TInstance Instance { get; set; }

        public TParam Validate<TParam>(Func<TParam> param)
        {
            //return o == null ? failureValue : evaluator(TOutput);

            return default(TParam);
            //return param;
        }


        public class ValidMessage
        {
            private List<string> _messages;

            /// <summary>
            /// 提示消息
            /// </summary>
            public List<string> Messages => _messages ?? (_messages = new List<string>());

            public int Count => Messages?.Count ?? 0;

            public void WithMessage(string msg)
            {
                Messages.Add(msg);
            }

        }
    }


    class Sample
    {
        public string Name { get; set; }
    }



}
