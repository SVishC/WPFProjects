using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeView
{
    public class TestVM:BaseViewModel
    {

        public string TestProperty { get; set; }
        public TestVM()
        {
            Task.Run(async() => 
            {
                int i = 1;
                while (true)
                {
                    TestProperty = i++.ToString();
                    await Task.Delay(200);
                }
            }
                );
        }
    }
}
