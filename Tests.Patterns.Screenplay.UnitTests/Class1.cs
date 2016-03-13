using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Patterns.Screenplay.UnitTests
{
    [TestFixture]
    public class ActorCan
    {
        [Test]
        // 1. Actor named John can perform the operation using a tool
        // 2. Actor, as John, can perform the operation using a tool
        public void ActorNamedJohnCanPerformTheOperationUsingATool()
        {
            Actor.Named("John")
                .Can(PerformOperation.Using(A.Tool()));
        }

        static class PerformOperation
        {
            public static Perform Using(object tool)
            {
                return null; 
            }
        }

        static class A
        {
            public static object Tool()
            {
                return null;
            }
        }
    }
}
