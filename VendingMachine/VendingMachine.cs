using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingMachine
    {
        public VendingMachine(int vendingMachineId) {
            VendingMachineId = vendingMachineId;

        }
        public int VendingMachineId { get; set; }


       

        public virtual ICollection<Product> Products { get; set;}
       
        
    }
}
