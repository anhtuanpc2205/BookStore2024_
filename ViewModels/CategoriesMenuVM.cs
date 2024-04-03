using BookStore2024.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookStore2024.ViewModels
{
	public class CategoriesMenuVM
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; } = null;
		public int Quantity {  get; set; }
	}
}
