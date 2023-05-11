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


        

        //stock the vending machine with products and add this to a list on this class
        //input money with testing
        //add money to transaction balance, create new one if no instance already
        //attmept to buy a product in the transaction using testing
        //use the same logic to calcualt the change and put it in a list, update abalance and product quantity 


       

        public virtual ICollection<Product> Products { get; set;}
       
        
    }
}
