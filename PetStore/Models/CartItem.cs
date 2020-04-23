using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    [Serializable]
    public class CartItem
    {
        public Pet Pet { get; set; }
        public int SoLuong { get; set; }

    }
}