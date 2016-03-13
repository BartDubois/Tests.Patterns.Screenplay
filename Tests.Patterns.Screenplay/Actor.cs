using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Patterns.Screenplay
{
    // TBD: Does the Serenity BDD implemntation valiotates single rsposibility prinicle [SRP]?
    public class Actor
    {
        // TBD: [SRP] Domain?
        protected Actor(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }
        private readonly string _name;

        // TBD: [SRP] Fluent?
        // 2. public static Actor As(string role) - it can be feather used to assign some bunch of allowed operations
        public static Actor Named(string withName)
        {
            return new Actor(withName);
        }

        public Actor Can(Perform operation)
        {
            return this;
        }
    }
}
