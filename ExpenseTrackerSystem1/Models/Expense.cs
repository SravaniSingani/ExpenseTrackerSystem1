using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerSystem1.Models
{
    public class Expense
    {

        //What describes an expense
        [Key]
        public int ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public string Category {  get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }

        //An expense has a Card Id
        //Each card has multiple expenses

        [ForeignKey("Card")]
        public int CardId { get; set; }
        public virtual Card Card { get; set; }

    }

    public class ExpenseDto
    {
        public int ExpenseId { get; set; }
        public string ExpenseName { get; set;}
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int CardId { get; set; }
        public string CardName { get; set; }
    }
}