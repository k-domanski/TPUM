using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.ViewModel
{
    public class ViewModelTest
    {
        ModelTest md = new ModelTest();

        public int Method()
        {
            return md.Method();
        }
    }
}
