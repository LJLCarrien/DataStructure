using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Learn
{
    class Girl : Person
    {
        private bool _disposed = false;
        public Girl(string firstName, string lastName) : base(firstName, lastName) { }

        protected override void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                //清理托管资源
            }
            _disposed = true;
            base.Dispose(disposing);
        }

        public override string ToString()
        {
            var r = string.Format("女：{0}{1}", FirstName, LastName);
            Console.WriteLine(r);
            return r;
        }
        /// <summary>
        /// 自定义隐式转换
        /// </summary>
        /// <param name="g"></param>
        public static implicit operator Boy(Girl g)
        {
            return new Boy(g.FirstName, g.LastName);
        }
        /// <summary>
        /// 自定义显式转换
        /// </summary>
        /// <param name="b"></param>
        public static explicit operator Girl(Boy b)
        {
            return new Girl(b.FirstName, b.LastName);
        }
    }
    class Boy : Person
    {
        public Boy(string firstName, string lastName) : base(firstName, lastName) { }

        public override string ToString()
        {
            var r = string.Format("男：{0}{1}", FirstName, LastName);
            Console.WriteLine(r);
            return r;
        }
    }

    class Person : IDisposable
    {
        private bool _disposed = false;
        ~Person()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                //清理托管资源
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            var r = this.FirstName + this.LastName;
            Console.WriteLine(r);
            return r;
        }


        public IEnumerator GetEnumerator()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
