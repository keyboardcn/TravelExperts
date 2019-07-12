using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Data
{

    public class Product
    {


        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name is too long!")]       
        public string ProdName { get; set; }


        // public Product Clone()
        //{
        //     Product copy = new Product();
        //   copy.ProductID = this.ProductID;
        //   copy.ProductName = this.ProductName;
        //    return copy;
        //    }


    }

}