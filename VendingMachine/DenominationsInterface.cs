using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface IGetDenominations
    {
        List<int> CalculateChange(int balance);
        
    }
}
