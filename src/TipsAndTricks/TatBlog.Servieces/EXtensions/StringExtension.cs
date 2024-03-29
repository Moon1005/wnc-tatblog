﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TatBlog.Services.Extensions
{
	public static class StringExtension
	{
			public static string RemoveAccent(this string txt)
			{
				byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
				return System.Text.Encoding.ASCII.GetString(bytes);
			}

			public static string GenerateSlug(this string phrase)
			{
				string str = phrase.RemoveAccent().ToLower();
				// invalid chars           
				str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
				// convert multiple spaces into one space   
				str = Regex.Replace(str, @"\s+", " ").Trim();
				// cut and trim 
				str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
				str = Regex.Replace(str, @"\s", "-"); // hyphens   
				return str;
			}
		
	}
}
