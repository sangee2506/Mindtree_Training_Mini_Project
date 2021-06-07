using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitAdminApi.ViewModels
{
    public class FruitDTO
    {
      
        

        public int FruitId { get; set; }
        
        public string FruitName { get; set; }
        
        public decimal FruitPrice { get; set; }

        public int FruitQty{ get; set; }

        public string FruitImgFile { get; set; }

        


    }
}
