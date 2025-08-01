﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public class OperationResult
    {
        
        public bool IsSucceddd { get; set; }
        public string Message { get; set; }
        public OperationResult()
        {
            IsSucceddd = false;
        }
        public OperationResult Succedded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSucceddd=true;
            Message = message;
            return this;
        }
        public OperationResult Failed(string message)
        {
            IsSucceddd = false;
            Message=message;
            return this;
        }      
    }
}
