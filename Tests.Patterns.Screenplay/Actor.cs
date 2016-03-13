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
        private readonly IDictionary<Type, Perform> AbilitiesTo = new Dictionary<Type, Perform>();

        public static Actor Named(string withName)
        {
            return new Actor(withName);
        }

        public Actor Can<TPerform>(TPerform operation)
            where TPerform : Perform
        {
            operation.As(this);
            AbilitiesTo.Add(typeof(TPerform), operation);

            return this;
        }
        public TPerform AbilityTo<TPerform>()
           where TPerform : Perform
        {
            return (TPerform)AbilitiesTo[typeof(TPerform)];
        }

        public void WasAbleTo(params Perform[] operations)
        {
            AttemptsTo(operations);
        }

        public void AttemptsTo(params Perform[] operations)
        {
            foreach (var operation in operations)
            {
                operation.As(this);
            }
        }


       
    }
}
