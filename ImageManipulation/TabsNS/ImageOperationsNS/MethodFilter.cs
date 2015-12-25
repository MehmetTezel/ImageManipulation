using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation.TabsNS.ImageOperationsNS
{
    public abstract class MethodFilter
    {
        public abstract string FilterName { get;  }
        public abstract bool IsMatched(Method task);
    }

    public class JustImportanTasksFilter : MethodFilter
    {
        public override string FilterName
        {
            get { return "Important only"; }
        }

        public override bool IsMatched(Method task)
        {
            if (task.IsImportant)
                return true;
            return false;
        }
    }

    public class AllTasksFilter : MethodFilter
    {
        public override string FilterName
        {
            get { return "Show all"; }
        }

        public override bool IsMatched(Method task)
        {
            return true;
        }
    }
}
