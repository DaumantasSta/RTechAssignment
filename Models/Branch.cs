using System;
using System.Collections.Generic;
using System.Text;

namespace ReizTechHWAssignment.Models
{
    public class Branch
    {
        public List<Branch> branches = new List<Branch>();

        public Branch this[int i]
        {
            get { return branches[i]; }
        }
    }
}
