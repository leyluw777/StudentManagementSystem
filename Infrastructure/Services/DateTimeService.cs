﻿using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DateTimeService : IDatetime
    {
        public DateTime Now => DateTime.Now;
    }
}
