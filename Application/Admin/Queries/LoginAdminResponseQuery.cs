﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Queries
{
	public class LoginAdminResponseQuery 
	{
		public bool IsAdmin { get; set; }
	}
}
