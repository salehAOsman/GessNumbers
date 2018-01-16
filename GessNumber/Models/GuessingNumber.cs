using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GessNumber.Models
{
    public class GuessingNumber
    {
        [Display (Name ="id")]
        public int Id { get; set; }
        [Display(Name = "Guessing Number")]
        public int GuessingNum { get; set; }
        [Display(Name= "Description")]
        public string Description { get; set; }
        
        //bettre to make list in individual place
        //public List<GuessingNumber> Guess = new List<GuessingNumber>();
        

        //GuessingNumber(int guess,string descript)
        //{
        //    Id++;
        //    GuessingNum = guess;
        //    Description = descript;
        //}
    }
}