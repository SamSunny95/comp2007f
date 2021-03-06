﻿/*
 * App: SuchiVille
 * File: Drink.cs
 * Developed by: Alex Andriishyn, Anthony Scinocco, Sam Parathuvayalil Sunny, Lyka Sunesara 
 * Purpose: Drink model
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
	public class Drink
	{
		public Drink() { }
		public virtual int DrinkId { get; set; }
		public virtual string Name { get; set; }
		public virtual string ThumbNail { get; set; }
		public virtual string FullImage { get; set; }
		public virtual string ShortDesc { get; set; }
		public virtual string FullDesc { get; set; }
		public virtual double Price { get; set; }
	}
}