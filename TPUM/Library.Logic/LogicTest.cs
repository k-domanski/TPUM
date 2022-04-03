using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;

namespace Library.Logic
{
    public class LogicTest
    {
        public DataTest d = new DataTest();
        
        public int Method()
        {
            return d.test;
        }
    }
}
